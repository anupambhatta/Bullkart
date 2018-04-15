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

        public void BuildOrderLine(string product)
        {
            bool alreadyExists = false;
            foreach (OrderLine ol in Order.OrderLines)
            {
                if (product.Equals(ol.Product.ProductName))
                {
                    ol.Quantity += 1;
                    alreadyExists = true;
                    break;
                }
            }
            if (!alreadyExists)
            {
                Product Product = repository.Products
                               .Where(p => p.ProductName == product)
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

        public List<Address> GetAddresses(int addressid)
        {
            return repository.Addresses
                    .Where(a => addressid == 0 || a.AddressId == addressid)
                    .OrderByDescending(a => a.Name)
                    .ToList();
        }

    }
}