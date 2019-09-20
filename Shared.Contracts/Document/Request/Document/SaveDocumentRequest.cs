using Microsoft.AspNetCore.Http;

namespace Shared.Contracts.Document.Request.Document
{
    public class SaveDocumentRequest
    {
        public long ProjectId { get; set; }

        public int DocumentTypeId { get; set; }

        public string TagId { get; set; }
        public IFormFile File { get; set; }
    }
}