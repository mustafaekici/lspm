using Shared.Core.EF;
using System;

namespace Infrastructure.Main.Models
{
    public class AssociatedContact : IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int AssociatedClientId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }

        #region Navigation Properties
        public virtual Client Client { get; set; }
        public virtual Client AssociatedClient { get; set; }
        #endregion
    }
}
