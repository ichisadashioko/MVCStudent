using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FUStudentMVC.Models;
using StudentLib.Services;

namespace FUStudentMVC.Controllers
{
    public class FUStudentsController : Controller
    {
        private FUDBContext db = new FUDBContext();
        private readonly IValidationService _validationService;
        public FUStudentsController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        // GET: FUStudents
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: FUStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUStudent fUStudent = db.Students.Find(id);
            if (fUStudent == null)
            {
                return HttpNotFound();
            }
            return View(fUStudent);
        }

        // GET: FUStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FUStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Credits,FirstName,LastName,Gender,EntryScore,DoB,HasCriminalRecord,Province,BankBalance")] FUStudent fUStudent)
        {
            if (ModelState.IsValid && _validationService.ValidateStudent(fUStudent))
            {
                db.Students.Add(fUStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fUStudent);
        }

        // GET: FUStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUStudent fUStudent = db.Students.Find(id);
            if (fUStudent == null)
            {
                return HttpNotFound();
            }
            return View(fUStudent);
        }

        // POST: FUStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Credits,FirstName,LastName,Gender,EntryScore,DoB,HasCriminalRecord,Province,BankBalance")] FUStudent fUStudent)
        {
            if (ModelState.IsValid && _validationService.ValidateStudent(fUStudent))
            {
                db.Entry(fUStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fUStudent);
        }

        // GET: FUStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUStudent fUStudent = db.Students.Find(id);
            if (fUStudent == null)
            {
                return HttpNotFound();
            }
            return View(fUStudent);
        }

        // POST: FUStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FUStudent fUStudent = db.Students.Find(id);
            db.Students.Remove(fUStudent);
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
