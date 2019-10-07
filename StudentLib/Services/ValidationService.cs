using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentLib.Models;

namespace StudentLib.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IEnumerable<IValidationRule> _validators;
        private IEnumerable<Type> _ignoredRules;

        public ValidationService()
        {
            _validators = GetBusinessRules();
            _ignoredRules = GetIgnoredRules();
        }

        protected virtual IEnumerable<IValidationRule> GetBusinessRules()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IValidationRule)
                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            if (_ignoredRules != null && _ignoredRules.Any())
            {

            }

            var validators = new List<IValidationRule>();
            foreach (var type in types)
            {
                var rule = Activator.CreateInstance(type) as IValidationRule;
                validators.Add(rule);
            }
            validators.OrderBy(x => x.Order);
            return validators;
        }

        public virtual bool ValidateStudent(Student student)
        {
            Debug.WriteLine($"_validators.Count(): {_validators.Count()}");
            if (_validators == null || !_validators.Any())
            {
                return true;
            }

            foreach (var validator in _validators)
            {
                int order = validator.Order;
                if (!validator.Validate(student))
                {
                    return false;
                }
            }
            return true;
        }
        protected virtual bool IsGenderAllowed(Student student)
        {
            return student.Gender == Gender.Male;
        }

        protected virtual IEnumerable<Type> GetIgnoredRules()
        {
            return null;
        }
    }
}