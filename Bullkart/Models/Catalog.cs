using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullkart.Models
{
    public class Catalog
    {
        public Category Category { get; set; }
        public int CatalogId { get; set; }
        public String CatalogName { get; set; }
        public String Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
