using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using codeFirstTask.Models;

namespace codeFirstTask.Controllers
{
    public class TeacherAssignmentsController : Controller
    {
        private schoolDBcontext db = new schoolDBcontext();

        // GET: TeacherAssignments
        public ActionResult Index()
        {
            var teacherAssignments = db.TeacherAssignments.Include(t => t.Assignment).Include(t => t.Teacher);
            return View(teacherAssignments.ToList());
        }

        // GET: TeacherAssignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssignment teacherAssignment = db.TeacherAssignments.Find(id);
            if (teacherAssignment == null)
            {
                return HttpNotFound();
            }
            return View(teacherAssignment);
        }

        // GET: TeacherAssignments/Create
        public ActionResult Create()
        {
            ViewBag.AssignmentID = new SelectList(db.Assignments, "ID", "Name");
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name");
            return View();
        }

        // POST: TeacherAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherAssignmentID,TeacherID,AssignmentID")] TeacherAssignment teacherAssignment)
        {
            if (ModelState.IsValid)
            {
                db.TeacherAssignments.Add(teacherAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignmentID = new SelectList(db.Assignments, "ID", "Name", teacherAssignment.AssignmentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", teacherAssignment.TeacherID);
            return View(teacherAssignment);
        }

        // GET: TeacherAssignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssignment teacherAssignment = db.TeacherAssignments.Find(id);
            if (teacherAssignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "ID", "Name", teacherAssignment.AssignmentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", teacherAssignment.TeacherID);
            return View(teacherAssignment);
        }

        // POST: TeacherAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherAssignmentID,TeacherID,AssignmentID")] TeacherAssignment teacherAssignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "ID", "Name", teacherAssignment.AssignmentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "Name", teacherAssignment.TeacherID);
            return View(teacherAssignment);
        }

        // GET: TeacherAssignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAssignment teacherAssignment = db.TeacherAssignments.Find(id);
            if (teacherAssignment == null)
            {
                return HttpNotFound();
            }
            return View(teacherAssignment);
        }

        // POST: TeacherAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherAssignment teacherAssignment = db.TeacherAssignments.Find(id);
            db.TeacherAssignments.Remove(teacherAssignment);
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
