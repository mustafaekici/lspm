using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class SiteCondition
    {
        public int SiteConditionID { get; set; }
        public int ProjectSiteConditionID { get; set; }
        public int SiteCategoryTypeID { get; set; }
        public int SiteConditionTypeID { get; set; }
        public int Coverage { get; set; }
        public int Factor { get; set; }
        public bool LOC { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ProjectSiteCondition ProjectSiteConditions { get; set; }

      
    }
}
