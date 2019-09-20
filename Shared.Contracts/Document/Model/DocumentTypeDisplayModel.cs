using System;

namespace Shared.Contracts.Document.Model
{
    public class DocumentTypeDisplayModel
    {
        public int Id { get; set; }

        public long ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string TypeName { get; set; }

        public int OrderNo { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }

}