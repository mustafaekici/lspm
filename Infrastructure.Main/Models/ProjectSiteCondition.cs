using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class ProjectSiteCondition
    {
        public int ProjectSiteConditionID { get; set; }
        public int ProjectID { get; set; }
        public string DisputesInfo { get; set; }
        public string SpecialInfo { get; set; }

        public Project Project { get; set; }

        public ICollection<SiteCondition> SiteConditions { get; set; }
    }
}
