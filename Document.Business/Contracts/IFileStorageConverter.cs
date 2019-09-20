using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LS.Document.Business.Contracts
{
    public interface IFileStorageConverter
    {
        byte[] ConvertToBytes(Stream downloadableStream);

        Stream ConvertToStream(byte[] bytes);
    }
}
