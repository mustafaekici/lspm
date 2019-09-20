using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class SiteConditionType
    {
        public int SiteConditionTypeID { get; set; }
        public int SiteCategoryTypeID { get; set; }
        [MaxLength(30)]
        public string SiteConditionTypeName { get; set; }

        public DateTime ModifiedDate { get; set; }

        public SiteCategoryType SiteCategoryType { get; set; }
    }
}
