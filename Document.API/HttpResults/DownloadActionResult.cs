using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace LS.Document.API.HttpResults
{
    public class DownloadActionResult : IActionResult
    {
        private readonly string _content;
        private readonly Stream _downloadableStream;
        private readonly string _fileName;

        public DownloadActionResult(string fileName, Stream downloadableStream)
        {
            if (downloadableStream == null) throw new ArgumentNullException(nameof(downloadableStream));

            _downloadableStream = downloadableStream;
            _fileName = fileName ?? "Unknown";
        }

        public DownloadActionResult(string content, string fileName)
        {
            if (content == null) throw new ArgumentNullException(nameof(content));
            _content = content;

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(content);
                    writer.Flush();
                    stream.Position = 0;
                }

                _downloadableStream = stream;
            }

            _fileName = fileName ?? "Unknown";
        }


        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage { Content = new StreamContent(_downloadableStream) };
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = _fileName };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = _downloadableStream.Length;

            return Task.FromResult(response);
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
