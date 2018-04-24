using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bullkart.Models;

namespace Bullkart.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IRepository repository) : base(repository) { }

        public IActionResult Index()
        {
            List<Category> Categories = GetAllCategoriesWithCatalogs();
            OrderCategoriesViewModel orderCategoriesViewModel = new OrderCategoriesViewModel(Categories, Order);
            return View(orderCategoriesViewModel);
        }

        public RedirectToActionResult AddToCart(int productid)
        {
            //Make the order null if it was already placed
            if(null != Order && 0 != Order.OrderId)
            {
                Order = null;
            }
            if(null == Order)
            {
                Order = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    StatusId = GetStatus(StatusEnum.NEW),
                    OrderLines = new List<OrderLine>()
                };
            }
            BuildOrderLine(productid); 
            return RedirectToAction("Index");
        }
        
        public RedirectToActionResult AddAddress(string name, string address1, string address2, string city, string state, string email)
        {
            if(null != Order)
            {
                Address Address = new Address
                {
                    Name = name,
                    Address1 = address1,
                    Address2 = address2,
                    City = city,
                    State = state,
                    Email = email
                };

                Order.Address = Address;
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult PlaceOrder()
        {
            if (null != Order)
            {
                repository.dbContext.Orders.Add(Order);
                foreach(OrderLine ol in Order.OrderLines)
                {
                    repository.dbContext.Products.Attach(ol.Product);
                }
                
                repository.dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int productid)
        {
            RemoveOrderLine(productid);
            return RedirectToAction("Index");
        }
    }
}