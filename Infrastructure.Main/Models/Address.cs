using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class Address:IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {
        public int Id { get; set; }
        //public int? AddressTypeId { get; set; } //home,billing,maioffice etc etc
        public int CityId { get; set; }     
        public string AddressLine1 { get; set; }   
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string PostalTown { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }     
        public DateTime? ModifiedDate { get; set; }      
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        #region Navigation Properties
        public virtual ICollection<Project> SiteAddresses { get; set; }
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
        //public virtual AddressType AddressType { get; set; }
        public virtual City City { get; set; }
        #endregion


    }
}
