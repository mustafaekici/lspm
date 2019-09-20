using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class AddressType : IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {

        public int Id { get; set; }
        public string AddressTypeName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        #region Navigation Properties
        //public virtual ICollection<Address> Adresses { get; set; }
        #endregion
    }
}
