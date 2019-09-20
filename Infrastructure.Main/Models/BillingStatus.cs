using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class BillingStatus
    {
        public int BillingStatusId { get; set; }

        [MaxLength(30)]
        public string Description { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
