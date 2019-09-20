using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class Client: IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {          
        public int Id { get; set; }
        public int? ClientRatingId { get; set; }
        public int? ContactTypeId { get; set; }      
        public string WebAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        #region Navigation Properties
        public virtual ContactType ContactType { get; set; }
        public virtual ClientRating ClientRating { get; set; }
        public virtual ICollection<ClientNote> ClientNotes { get; set; }
        public virtual ICollection<AssociatedContact> Clients { get; set; }
        public virtual ICollection<AssociatedContact> AssociatedClients { get; set; }
        public virtual ICollection<AssociatedProject> AssociatedProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ClientCompany> ClientCompanies { get; set; }
        public virtual ICollection<ClientAddress> ClientAddresses { get; set; }
        #endregion

    }
}
