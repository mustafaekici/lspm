using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document.Models
{
    public class Document : IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {
        public int Id { get; set; }
        public long ProjectId { get; set; }
        public int DocumentTypeId { get; set; }
        public string Tag { get; set; }
        public byte[] Content { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        #region Navigation Properties

        public virtual Project Project { get; set; }
        public virtual DocumentType DocumentType { get; set; }

        #endregion
    }
}
