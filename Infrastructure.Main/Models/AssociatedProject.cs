using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class AssociatedProject : IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {
        //public int AssociatedProjectID { get; set; }
        //public int ProjectID { get; set; }
        //public int ClientID { get; set; } //data going to delete when a contact is deleted.
        //public int AssociatedProjectRelationID { get; set; }
        //public bool IsPayer { get; set; }
        //[Required]
        //public DateTime ModifiedDate { get; set; }
        //public string Note { get; set; }
        //public Client Client { get; set; }
        //public AssociatedProjectRelation AssociatedProjectRelation { get; set; }
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsPayer { get; set; }
        public string Note { get; set; }
        public string RelationDescription { get; set; }

        #region Navigation Properties
        public virtual Client Client { get; set; }
        public virtual Project Project { get; set; }
        #endregion
    }
}
