using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullkart.Models
{
    public class OrderCategoriesViewModel
    {
        public List<Category> Categories { get; set;  }
        public Order Order { get; set; }

        public OrderCategoriesViewModel(List<Category> cats, Order order)
        {
            Categories = cats;
            Order = order;
        }

    }
}
