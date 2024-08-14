using Ecomerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecomerce.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            var products = Session["Products"] as List<Product> ?? new List<Product>();
            products.Add(product);
            Session["Products"] = products;

            return RedirectToAction("ProductList");
        }

        public ActionResult ProductList()
        {
            List<Product> products = Session["Products"] as List<Product> ?? new List<Product>();
            return View(products);
        }
    }
}
