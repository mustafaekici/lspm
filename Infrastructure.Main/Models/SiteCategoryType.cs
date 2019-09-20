using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class SiteCategoryType
    {
        public int SiteCategoryTypeID { get; set; }
        [MaxLength(15)]
        public string SiteCategoryTypeName { get; set; } //Brusha,Trees,Slope,Wetlands,Access,Improvements
  
        public DateTime ModifiedDate { get; set; }
        public ICollection<SiteConditionType> SiteConditionTypes { get; set; }
    }
}
