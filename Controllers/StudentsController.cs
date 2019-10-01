using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentMVC.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Text;
using StudentMVC.Services;
using System.Diagnostics;
using System.Web.Mvc.Html;

namespace StudentMVC.Controllers
{
    public class StudentsController : Controller
    {
        private StudentDBContext db = new StudentDBContext();
        private Validation Validation = new Validation();

        public PartialViewResult AjaxCreate()
        {
            return PartialView("_PartialCreateForm");
        }

        [HttpPost]
        public JsonResult AjaxCreate([Bind(Include = "ID,FirstName,LastName,Gender,DoB")] Student student)
        {
            if (ModelState.IsValid && Validation.validateStudent(student))
            {
                db.Students.Add(student);
                db.SaveChanges();
                //MvcHtmlString x = DisplayExtensions.DisplayFor < Student, DateTime>()
                return Json(new
                {
                    success = true,
                    student = new
                    {
                        ID = student.ID,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Gender = student.Gender.ToString(),
                        DoB = student.DoB.ToString("yyyy-MM-dd"), // how to use `@Html.DisplayFor`
                    }
                });
            }
            return Json(new { success = false });
        }

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpGet]
        public ActionResult JsonView()
        {
            return View();
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Gender,DoB")] Student student)
        {
            if (ModelState.IsValid && Validation.validateStudent(student))
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Gender,DoB")] Student student)
        {
            if (ModelState.IsValid && Validation.validateStudent(student))
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
