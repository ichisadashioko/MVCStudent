using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BKStudentMVC.Models;
using StudentLib.Services;

namespace BKStudentMVC.Controllers
{
    public class BKStudentsController : Controller
    {
        private BKStudentDBContext db = new BKStudentDBContext();
        private readonly IValidationService _validationService;
        public BKStudentsController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        // GET: BKStudents
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: BKStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BKStudent bKStudent = db.Students.Find(id);
            if (bKStudent == null)
            {
                return HttpNotFound();
            }
            return View(bKStudent);
        }

        // GET: BKStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BKStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UndergraduateYears,FirstName,LastName,Gender,EntryScore,DoB,HasCriminalRecord,Province,BankBalance")] BKStudent bKStudent)
        {
            if (ModelState.IsValid && _validationService.ValidateStudent(bKStudent))
            {
                db.Students.Add(bKStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bKStudent);
        }

        // GET: BKStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BKStudent bKStudent = db.Students.Find(id);
            if (bKStudent == null)
            {
                return HttpNotFound();
            }
            return View(bKStudent);
        }

        // POST: BKStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UndergraduateYears,FirstName,LastName,Gender,EntryScore,DoB,HasCriminalRecord,Province,BankBalance")] BKStudent bKStudent)
        {
            if (ModelState.IsValid && _validationService.ValidateStudent(bKStudent))
            {
                db.Entry(bKStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bKStudent);
        }

        // GET: BKStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BKStudent bKStudent = db.Students.Find(id);
            if (bKStudent == null)
            {
                return HttpNotFound();
            }
            return View(bKStudent);
        }

        // POST: BKStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BKStudent bKStudent = db.Students.Find(id);
            db.Students.Remove(bKStudent);
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
