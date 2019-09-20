using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class CountryRegion
    {
   
        public int CountryRegionID { get; set; }

        [MaxLength(3)]
        public string CountryRegionCode { get; set; }
        [MaxLength(50)]
        public string CountryName { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public ICollection<StateProvince> StateProvinces { get; set; }
    }
}
