using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class ClientAddress
    {
        public int ClientAddressID { get; set; }
        public int AddressID { get; set; }
        //adresstypeid
        public int ClientID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Address Address { get; set; }
        public Client Client { get; set; }

    }
}
