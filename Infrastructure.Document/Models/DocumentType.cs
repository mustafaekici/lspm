using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document.Models
{
    public class DocumentType : IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {
        public int Id { get; set; }
        public long ProjectId { get; set; }
        public string TypeName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int OrderNo { get; set; }

        #region Navigation Properties

        public virtual Project Project { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        #endregion
    }
}
