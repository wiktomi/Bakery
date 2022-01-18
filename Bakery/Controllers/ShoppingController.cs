using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;
using AutoMapper;

namespace Bakery.Controllers
{
    public class ShoppingController : Controller
    {
        BakeryAzureEntities db = new BakeryAzureEntities();

         

        // GET: Shopping
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            var prod = db.Products.SingleOrDefault(p => p.ProductID == id);

            var shoppingcart = new ShoppingCart()
            {
                ProductName = prod.ProductName,
                Price = prod.ProductPrice,
                StartDate = DateTime.Now
            };
            db.ShoppingCarts.Add(shoppingcart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}