using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document.Models
{
    public class Project : IEntity<long>, ISoftDelete, IAuditable, ICreate, IModify
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        #region Navigation Properties

        public virtual ICollection<DocumentType> DocumentTypes { get; set; }
        public virtual ICollection<Document> Documents { get; set; }

        #endregion
    }
}
