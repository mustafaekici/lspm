using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class ClientPhone
    {
        public int PhoneID { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public int PhoneTypeID { get; set; }

        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        public int? Ext { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
 
        public PhoneType PhoneType { get; set; }

 

    }
}
