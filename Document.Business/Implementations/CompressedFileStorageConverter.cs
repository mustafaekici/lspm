using LS.Document.Business.Contracts;
using LS.Document.Business.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LS.Document.Business.Implementations
{
    public class CompressedFileStorageConverter : IFileStorageConverter
    {
        public byte[] ConvertToBytes(Stream downloadableStream)
        {
            using (var memoryStream = new MemoryStream())
            {
                downloadableStream.CopyTo(memoryStream);
                return ByteArrayCompressionHelper.Compress(memoryStream.ToArray());
            }
        }

        public Stream ConvertToStream(byte[] bytes)
        {
            var deCompressedContent = ByteArrayCompressionHelper.Decompress(bytes);
            return new MemoryStream(deCompressedContent);
        }
    }
}
