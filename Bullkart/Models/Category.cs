using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullkart.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public String Description { get; set; }
        public List<Catalog> Catalogs { get; set; }
        public List<Product> Products { get; set; }
    }
}
