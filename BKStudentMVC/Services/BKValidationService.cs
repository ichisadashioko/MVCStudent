
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
            // Scan all assemblies
            // Get all class `Type`
            // Check whether the `Type` is active or not
            // If yes then add the `Type` instance to return

            // Move `ruleModels` to an interface
            var db = new RuleDBEntities();
            var ruleModels = db.RuleModels.ToList();

            // Make DI container get `types`
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IValidationRule)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            // check rule status (active or not) using interface
            var activeRules = types.Where(t => ruleModels.Any(r => (r.FullName.Trim().Equals(t.FullName)) && r.InEffect));

            // Use DI container to create instance
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