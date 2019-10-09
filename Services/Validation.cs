using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using StudentMVC.Models;
using System.Reflection;
using StructureMap;
using System.Diagnostics;
using StudentMVC.DependencyResolution;

namespace StudentMVC.Services
{
    public interface IValidationService
    {
        bool ValidateStudent(Student student);
    }

    public class ValidationService : IValidationService
    {
        private readonly IEnumerable<IValidationRule> _validators;
        public ValidationService()
        {
            _validators = GetBusinessRules();
        }

        protected virtual IEnumerable<IValidationRule> GetBusinessRules()
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
    }
}