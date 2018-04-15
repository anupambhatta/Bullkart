using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bullkart.Models
{
    public class CategoriesAddressesViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Address> Addresses { get; set; }

        public CategoriesAddressesViewModel(List<Category> cats, List<Address> ads)
        {
            Categories = cats;
            Addresses = ads;
        }
    }
}
