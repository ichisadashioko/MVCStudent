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

namespace BKStudentMVC.Models
{
    public class RuleModel
    {
        public RuleModel() { }
        public RuleModel(IValidationRule rule)
        {
            FullName = rule.GetType().FullName;
            Description = rule.Description;
            Active = true;
        }

        public string FullName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public override string ToString()
        {
            Type objType = this.GetType();
            PropertyInfo[] propertyInfoList = objType.GetProperties();
            StringBuilder result = new StringBuilder();
            foreach (var propertyInfo in propertyInfoList)
            {
                result.Append($"{propertyInfo.Name}={propertyInfo.GetValue(this)}, ");
            }
            return result.ToString();
        }
    }
}

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
        private readonly ValidationService _validators;
        public HomeController(ValidationService validators)
        {
            _validators = validators;
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Rules(int page)
        //{
        //    Response.Cache.SetOmitVaryStar(true);
        //    //var rules = _validators.
        //}
    }
}