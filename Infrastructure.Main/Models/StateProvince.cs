using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class StateProvince
    {
        public int StateProvinceID { get; set; }
        public int CountryRegionID { get; set; }

        [MaxLength(3)]
        public string StateProvinceCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        [MaxLength(30)]
        public string StateName { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public CountryRegion CountryRegion { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
