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

    public class MyValidation : Validation
    {
        protected override bool IsGenderAllowed(Student student)
        {
            return student.Gender == Gender.Female;
        }
    }

    public class Validation : IValidationService
    {
        private readonly IEnumerable<IValidationRule> _validators;
        public Validation()
        {
            _validators = GetBusinessRules();
        }

        protected virtual IEnumerable<IValidationRule> GetBusinessRules()
        {
            /************* StructureMap ************/
            //var container = new Container(_ =>
            //{
            //    _.Scan(x =>
            //    {
            //        x.TheCallingAssembly();
            //        x.AddAllTypesOf<IValidationRule>();
            //        x.WithDefaultConventions();
            //    });
            //});
            var registry = new DefaultRegistry();
            var container = new Container(registry);


            Debug.WriteLine(container.WhatDidIScan());
            Debug.WriteLine(container.WhatDoIHave());

            return container.GetAllInstances<IValidationRule>().OrderBy(x => x.Order);
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