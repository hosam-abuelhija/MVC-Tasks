using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Task_6.Models;

namespace MVC_Task_6.Controllers
{
    public class UsersController : Controller
    {
        private MVCTASK6Entities db = new MVCTASK6Entities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string password)
        {
            var user = db.Users.SingleOrDefault(u => u.Email == Email);
            if (user != null && user.password == password)
            {
                Session["ID"] = user.ID;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = "Invalid Email or password.";
            return View();
        }

        // GET: Login/Logout
        public ActionResult Logout()
        {
            Session["ID"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Regester()
        {
            return View();
        }
        

        public ActionResult Profile()
        {
            var id = Session["ID"];
            var user = db.Users.Find(id);
            return View(user);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(HttpPostedFileBase imageFile)
        {
            var userId = Session["ID"];
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = db.Users.Find(userId);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (imageFile != null && imageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var path = Path.Combine(Server.MapPath("~/Images/"), uniqueFileName);

                imageFile.SaveAs(path);

                // Delete the old image file if it exists
                if (!string.IsNullOrEmpty(user.IMG))
                {
                    var oldImagePath = Path.Combine(Server.MapPath("~/Images"), user.IMG);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                user.IMG = uniqueFileName;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Profile");
        }


        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Regester(User user, string confirm)
        {
            if (ModelState.IsValid)
            {
                if (user.password != confirm)
                    return View();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,password,IMG")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profile");
            }
            return View(user);
        }

        public ActionResult ResetPassword()
        {
            var userId = Session["ID"];
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string oldPassword, string newPassword, string confirmPassword)
        {
            var userId = Session["ID"];
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = db.Users.Find(userId);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (user.password != oldPassword)
            {
                ModelState.AddModelError("", "Old password is incorrect.");
                return View();
            }

            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("", "New password and confirmation password do not match.");
                return View();
            }

            user.password = newPassword;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            ViewBag.SuccessMessage = "Password has been reset successfully.";
            return View();
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
