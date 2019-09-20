using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Main.Models
{
    public class Company
    {
        public int CompanyID { get; set; }

        public int BusinessTypeID { get; set; }
        [MaxLength(30)]
        public string CompanyName { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }

        public byte[] Picture { get; set; }

        public BusinessType BusinessType { get; set; }
        
        public ICollection<ClientCompany> ClientCompanies { get; set; }

    }
}
