
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StudentLib.Models;
using StudentLib.Services;
using BKStudentMVC.Models;

namespace BKStudentMVC.Services
{
    public class BKValidationService : ValidationService
    {
        protected override IEnumerable<Type> GetIgnoredRules()
        {
            return new List<Type>()
            {
                typeof(GenderValidationRule),
            };
        }

        protected override IEnumerable<IValidationRule> GetBusinessRules()
        {
            var db = new RuleDBContext();
            var ruleModels = db.RuleModels.ToList();

            var validators = new List<IValidationRule>();
            foreach (var ruleModel in ruleModels)
            {
                Debug.WriteLine($"[BKValidationService.GetBusinessRules] Trying to load {ruleModel.FullName}");
                if (ruleModel.InEffect())
                {
                    var type = Type.GetType(ruleModel.FullName);
                    Debug.WriteLine($"[BKValidationService.GetBusinessRules] Got type {type}");
                    //var validator = Activator.CreateInstance(type) as IValidationRule;
                    //validators.Add(validator);
                }
            }
            return validators;

            //return ruleModels.Where(x => x.InEffect())
            //.Select(x => Activator.CreateInstance(Type.GetType(x.FullName)) as IValidationRule);
            //return base.GetBusinessRules();
        }
    }
}