using System;
using Newtonsoft.Json;

namespace Shared.Contracts.Document.Model
{
    public class DocumentDisplayModel
    {
        public int DocumentId { get; set; }

        public long DocumentTypeId { get; set; }

        public long ProjectId { get; set; }

        public string DocumentType { get; set; }

        public string Project { get; set; }

        public string FileName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

    }
}