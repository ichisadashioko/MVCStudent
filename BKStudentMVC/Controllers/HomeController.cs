using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKStudentMVC.Models;
using BKStudentMVC.ViewModels;
using StudentLib.Services;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;


namespace BKStudentMVC.ViewModels
{
    public class RuleViewModel
    {
        public IEnumerable<RuleModel> Rules { get; set; }
        public int RulesPerPage { get; set; }
        public int Page { get; set; }
    }
}

namespace BKStudentMVC.Controllers
{
    public class HomeController : Controller
    {
        private const int RULES_PER_PAGE = 3;
        private readonly RuleDBContext ruleDB;
        public HomeController()
        {
            ruleDB = new RuleDBContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rules(int page)
        {
            Response.Cache.SetOmitVaryStar(true);
            var rules = ruleDB.RuleModels.Skip((page - 1) * RULES_PER_PAGE).Take(RULES_PER_PAGE);
            var hasMore = page * RULES_PER_PAGE < ruleDB.RuleModels.Count();

            if (ControllerContext.HttpContext.Request.ContentType == "application/json")
            {
                return Json(new
                {
                    rules = rules,
                    hasMore = hasMore,
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(new RuleViewModel
                {
                    Rules = ruleDB.RuleModels.Take(RULES_PER_PAGE * page),
                    RulesPerPage = RULES_PER_PAGE,
                    Page = page,
                });
            }
        }
    }
}