using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bullkart.Controllers;

namespace Bullkart.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int StatusId { get; set; }
        public DateTime? OrderDate { get; set; }
        public Address Address { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        public decimal OrderTotal()
        {
            decimal total = 0.00M;
            foreach(OrderLine ol in OrderLines)
            {
                total += ol.Amount;
            }
            return total;
        }

        public void ResetOrder()
        {
            OrderController.Order = null;
        }
    }
}
