using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullkart.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public DateTime? OrderDate { get; set; }
        public Address Address { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
