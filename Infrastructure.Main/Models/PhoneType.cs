using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class PhoneType
    {
        public int PhoneTypeID { get; set; }
        [MaxLength(30)]
        public string PhoneTypeName { get; set; } //home,work,etc
        [Required]
        public DateTime ModifiedDate { get; set; }

        //---
        public ICollection<ClientPhone> Phones { get; set; }
    }
}
