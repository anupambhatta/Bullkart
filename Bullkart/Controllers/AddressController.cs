using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bullkart.Models;


namespace Bullkart.Controllers
{
    public class AddressController : BaseController
    {
        public AddressController(IRepository repository) : base(repository) { }

        public IActionResult Index()
        {
            return View(GetCategoriesAddressesViewModel(0));
        }

        public IActionResult EditAddress(int addressid)
        {
            return View(GetCategoriesAddressesViewModel(addressid));
        }

        public CategoriesAddressesViewModel GetCategoriesAddressesViewModel(int addressid)
        {
            List<Category> Categories = GetAllCategoriesWithCatalogs();
            List<Address> Addresses = GetAddresses(addressid);
            return (new CategoriesAddressesViewModel(Categories, Addresses));
        }

        public RedirectToActionResult UpdateAddress(int addressid, string name, string address1, string address2, string city, string state, string email)
        {
            List<Address> Addresses = GetAddresses(addressid);
            foreach(Address ad in Addresses)
            {
                ad.Address1 = address1;
                ad.Address2 = address2;
                ad.Name = name;
                ad.City = city;
                ad.State = state;
                ad.Email = email;
            }
            repository.dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectToActionResult DeleteAddress(int addressid)
        {
            foreach(Address ad in GetAddresses(addressid))
            {
                repository.dbContext.Addresses.Remove(ad);
            }
            repository.dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}