using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullkart.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}
