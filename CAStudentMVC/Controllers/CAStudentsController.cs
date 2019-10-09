using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CAStudentMVC.Models;
using StudentLib.Services;

namespace CAStudentMVC.Controllers
{
    public class CAStudentsController : Controller
    {
        private CAStudentDBContext db = new CAStudentDBContext();
        private readonly IValidationService _validationService;
        public CAStudentsController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        // GET: CAStudents
        public ActionResult Index()
        {
            return View(db.CAStudents.ToList());
        }

        // GET: CAStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAStudent cAStudent = db.CAStudents.Find(id);
            if (cAStudent == null)
            {
                return HttpNotFound();
            }
            return View(cAStudent);
        }

        // GET: CAStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CAStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Height,WasParentInService,FirstName,LastName,Gender,EntryScore,DoB,HasCriminalRecord,Province,BankBalance")] CAStudent cAStudent)
        {
            if (ModelState.IsValid && _validationService.ValidateStudent(cAStudent))
            {
                db.CAStudents.Add(cAStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cAStudent);
        }

        // GET: CAStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAStudent cAStudent = db.CAStudents.Find(id);
            if (cAStudent == null)
            {
                return HttpNotFound();
            }
            return View(cAStudent);
        }

        // POST: CAStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Height,WasParentInService,FirstName,LastName,Gender,EntryScore,DoB,HasCriminalRecord,Province,BankBalance")] CAStudent cAStudent)
        {
            if (ModelState.IsValid && _validationService.ValidateStudent(cAStudent))
            {
                db.Entry(cAStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cAStudent);
        }

        // GET: CAStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CAStudent cAStudent = db.CAStudents.Find(id);
            if (cAStudent == null)
            {
                return HttpNotFound();
            }
            return View(cAStudent);
        }

        // POST: CAStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CAStudent cAStudent = db.CAStudents.Find(id);
            db.CAStudents.Remove(cAStudent);
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
