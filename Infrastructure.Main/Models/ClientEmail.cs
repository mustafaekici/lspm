using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class ClientEmail
    {
        public int EmailID { get; set; }
        //pk
        public int EmailTypeID { get; set; }

        [MaxLength(50)]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        //--

        public EmailType EmailType { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
    }
}
