using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullkart.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public String Description { get; set; }
        public Catalog Catalog { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
    }
}
