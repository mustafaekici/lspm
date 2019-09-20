using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class EmailType
    {
        public int EmailTypeID { get; set; }
        [MaxLength(30)]
        public string EmailTypeName { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        
        public ICollection<ClientEmail> Emails { get; set; }
    }
}
