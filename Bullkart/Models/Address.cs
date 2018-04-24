using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bullkart.Controllers;
namespace Bullkart.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }
    }

    
}
