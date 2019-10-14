
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
            var db = new RuleDBEntities();
            var ruleModels = db.RuleModels.ToList();
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IValidationRule)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            var activeRules = types.Where(t => ruleModels.Any(r => (r.FullName.Trim().Equals(t.FullName)) && r.InEffect));


            var validators = new List<IValidationRule>();
            foreach (var type in activeRules)
            {
                Debug.WriteLine($"[BKStudentMVC.Services.BKValidationService.GetBusinessRules] Adding {type.FullName} to rule list.");
                var rule = Activator.CreateInstance(type) as IValidationRule;
                validators.Add(rule);
            }
            validators.OrderBy(x => x.Order);
            return validators;
        }
    }
}