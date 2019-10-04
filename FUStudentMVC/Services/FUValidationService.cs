
using StudentLib.Models;
using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace FUStudentMVC.Services
{
    public class EntryScoreValidationRule : IValidationRule
    {
        public int Order => 1;

        public bool Validate(Student student)
        {
            return student.EntryScore > 7.6;
        }
    }
    public class FUValidationService : ValidationService
    {
        protected override IEnumerable<IValidationRule> GetBusinessRules()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IValidationRule)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            var validators = new List<IValidationRule>();
            foreach (var type in types)
            {
                var rule = Activator.CreateInstance(type) as IValidationRule;
                validators.Add(rule);
                Debug.WriteLine(type.FullName);
            }
            validators.OrderBy(x => x.Order);
            return validators;
        }
    }
}