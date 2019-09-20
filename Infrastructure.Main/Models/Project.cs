using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class Project : IEntity<int>, ISoftDelete, IAuditable, ICreate, IModify
    {
        public int Id { get; set; }
        public int SiteAddressId { get; set; }
        public int ClientId { get; set; }
        public int ProjectManagerId { get; set; } //project manager EmployeeId
        public int ProjectStatusId { get; set; }
        public int BillingStatusId { get; set; }
        public int? InitialContactId { get; set; } //EmployeeId
        public DateTime? InitialContactDate { get; set; }
        public DateTime? CallBackDateDate { get; set; }
        public DateTime? CrewScheduleDate { get; set; }
        public DateTime? OfficeDueDate { get; set; }
        public DateTime? RequiredDueDate { get; set; }
        public DateTime? GoDate { get; set; }
        public DateTime? CloseDate { get; set; }  
        public string ProjectName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }

        #region Navigation Properties
        public Address SiteAddress { get; set; }
        public Client Client { get; set; }
        public Employee ProjectManager { get; set; }
        public Employee InitialContact { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public BillingStatus BillingStatus { get; set; }
      
  
        public ICollection<ProjectNote> ProjectNotes { get; set; }
        public ICollection<ProjectSiteCondition> ProjectSiteConditions { get; set; }
        #endregion

    }
}
