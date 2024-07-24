using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Task_3.Controllers
{
    public class AccountController : Controller
    {


        private static readonly (string Email, string Password)[] valid =
       {
            ("hosam.adnan123@gmail.com", "123")
       };

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        // POST: Account
        [HttpPost]
        public ActionResult Login(string Email, string password)
        {
            bool isValidUser = valid.Any(g => g.Email == Email && g.Password == password);

            if (isValidUser)
            {
                Session["User"] = Email;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid Email or password.";
            return View();
        }

        // GET: Login/Logout
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
            return View();
        }
    }
}