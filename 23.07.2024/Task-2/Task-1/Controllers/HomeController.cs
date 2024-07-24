using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult SubmitContact(string name, string phone, string contactMethod, string subject, string[] services, string message)
        {
            ViewBag.Name = name;
            ViewBag.Phone = phone;
            ViewBag.ContactMethod = contactMethod;
            ViewBag.Subject = subject;
            ViewBag.Services = services != null ? string.Join(", ", services) : "None";
            ViewBag.Message = message;

            return View("ContactResult");
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}