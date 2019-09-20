using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class WorkCode
    {
        public int WorkCodeID { get; set; }
        public string WorkCodeName { get; set; }
        public string WorkCodeDefinition { get; set; }
        public bool HasBenefit { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<WorkBenefit> WorkBenefits { get; set; }
    }
}
