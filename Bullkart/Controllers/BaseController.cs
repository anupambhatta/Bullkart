using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bullkart.Models;
namespace Bullkart.Controllers
{
    public class BaseController : Controller
    {
        public static Order Order;

        public IRepository repository;

        public BaseController(IRepository repo)
        {
            repository = repo;
        }

        //helper functions
        public List<Category> GetAllCategories()
        {
            return repository.Categories
                   .OrderByDescending(cat => cat.CategoryId)
                   .ToList();
        }

        public List<Catalog> GetCatalogsPerCategory(Category category)
        {
            return repository.Catalogs
                   .Where(c => c.Category == category)
                   .ToList();
        }

        public List<Category> GetAllCategoriesWithCatalogs()
        {
            List<Category> categories = GetAllCategories();

            //Add the catalogs to respective category
            foreach (Category category in categories)
            {
                category.Catalogs = GetCatalogsPerCategory(category);
            }
            return categories;
        }

        public int GetStatus(string status)
        {
            return repository.Statuses
                    .Where(s => s.StatusCode == status)
                    .Select(s => s.StatusId)
                    .FirstOrDefault();
        }

        public void BuildOrderLine(int productid)
        {
            bool alreadyExists = false;
            foreach (OrderLine ol in Order.OrderLines)
            {
                if (productid == ol.Product.ProductId)
                {
                    ol.Quantity += 1;
                    ol.Amount += ol.Amount;
                    alreadyExists = true;
                    break;
                }
            }
            if (!alreadyExists)
            {
                Product Product = repository.Products
                               .Where(p => p.ProductId == productid)
                               .FirstOrDefault();
                OrderLine orderLine = new OrderLine
                {
                    Product = Product,
                    Quantity = 1,
                    Amount = Product.Price * 1
                };
                Order.OrderLines.Add(orderLine);
            }
        }

        public void RemoveOrderLine(int productid)
        {
            if(null != Order.OrderLines)
            {
                OrderLine rmol = null;
                foreach(OrderLine ol in Order.OrderLines)
                {
                    if(ol.Product.ProductId == productid)
                    {
                        rmol = ol;
                        break;
                    }
                }
                if(null != rmol)
                {
                    Order.OrderLines.Remove(rmol);
                }
            }

        }
        public List<Address> GetAddresses(int addressid)
        {
            if(addressid == -1)
            {
                Address address = new Address
                {
                    Name = "",
                    Address1 = "",
                    Address2 = "",
                    City = "",
                    State = "",
                    Email = ""
                };
                List<Address> addresses = new List<Address>
                {
                    address
                };
                return addresses;
            }
            List<Address> addresses1 = repository.Addresses
                                        .Where(a => addressid == 0 || a.AddressId == addressid)
                                        .OrderByDescending(a => a.Name)
                                        .ToList();
            foreach(Address address in addresses1)
            {
                address.Orders = GetOrdersByAddress(address.AddressId);
            }
            return addresses1;
        }

        public List<Order> GetOrdersByAddress(int addressid)
        {
            return repository.Orders
                    .Where(o => o.Address.AddressId == addressid)
                    .ToList();
        }

    }
}