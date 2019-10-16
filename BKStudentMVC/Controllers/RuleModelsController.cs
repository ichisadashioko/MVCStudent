using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BKStudentMVC.Models;

namespace BKStudentMVC.Controllers
{
    public class RuleModelsController : Controller
    {
        private BKDBContext db = new BKDBContext();

        // GET: RuleModels
        public ActionResult Index()
        {
            return View(db.RuleModels.ToList());
        }

        // GET: RuleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RuleModel ruleModel = db.RuleModels.Find(id);
            if (ruleModel == null)
            {
                return HttpNotFound();
            }
            return View(ruleModel);
        }

        // GET: RuleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RuleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Description,Active,StartDate,EndDate")] RuleModel ruleModel)
        {
            if (ModelState.IsValid)
            {
                db.RuleModels.Add(ruleModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ruleModel);
        }

        // GET: RuleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RuleModel ruleModel = db.RuleModels.Find(id);
            if (ruleModel == null)
            {
                return HttpNotFound();
            }
            return View(ruleModel);
        }

        // POST: RuleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Description,Active,StartDate,EndDate")] RuleModel ruleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruleModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ruleModel);
        }

        // GET: RuleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RuleModel ruleModel = db.RuleModels.Find(id);
            if (ruleModel == null)
            {
                return HttpNotFound();
            }
            return View(ruleModel);
        }

        // POST: RuleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RuleModel ruleModel = db.RuleModels.Find(id);
            db.RuleModels.Remove(ruleModel);
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
