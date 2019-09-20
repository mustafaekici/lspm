using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class City
    {
        public int CityID { get; set; }
        public int StateProvinceID { get; set; }

        [MaxLength(30)]
        public string CityName { get; set; }
        [MaxLength(30)]
        public string County { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public StateProvince StateProvince { get; set; }

        public ICollection<Address> Adresses { get; set; }

    }
}
