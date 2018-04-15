using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;
using Bullkart.Models;

namespace Bullkart.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IRepository repository) : base(repository) { }
        
        public IActionResult Index()
        {
            return View(GetAllCategoriesWithCatalogs());
        }

        public IActionResult ProductList(String category, String catalog)
        {
            List<Category> categories = GetAllCategoriesWithCatalogs();
            //Add products only for the category 
            foreach(Category cat in categories)
            {
                if (!cat.CategoryName.Equals(category))
                    continue;
                cat.Products = repository.Products
                                .Where(p => p.Category.CategoryName == category)
                                .Where(p => catalog == null || p.Catalog.CatalogName == catalog)
                                .ToList();
            }
            return View(categories);
        }
       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
