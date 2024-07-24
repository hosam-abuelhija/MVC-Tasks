using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_3.Models;

namespace Task_3.Controllers
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

        private static List<ContactFormEntry> submittedContacts = new List<ContactFormEntry>();

        // GET: Contact
        public ActionResult Contact()
        {
            ViewBag.SubmittedContacts = submittedContacts;
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name, string email, string message)
        {
            if (ModelState.IsValid)
            {
                var entry = new ContactFormEntry
                {
                    Name = name,
                    Email = email,
                    Message = message
                };

                submittedContacts.Add(entry);

                ViewBag.Name = string.Empty;
                ViewBag.Email = string.Empty;
                ViewBag.Message = string.Empty;

                ViewBag.SubmittedContacts = submittedContacts;

                return View();
            }

            
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Message = message;
            ViewBag.SubmittedContacts = submittedContacts;
            return View();
        }
    }

}
