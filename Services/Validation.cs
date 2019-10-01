using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using StudentMVC.Models;
using System.Reflection;
using Autofac;

namespace StudentMVC.Services
{
    public interface IValidationService
    {
        bool validateStudent(Student student);
    }

    public class MyValidation : Validation
    {
        protected override bool IsGenderAllowed(Student student)
        {
            return student.Gender == Gender.Female;
        }
    }

    public interface IValidationRule
    {
        int Order { get; }
        bool Validate(Student student);
    }

    public class GenderValidationRule : IValidationRule
    {
        public virtual int Order => 100;

        public bool Validate(Student student)
        {
            return student.Gender == Gender.Male;
        }
    }

    public class AgeValidationRule : IValidationRule
    {
        public virtual int Order => 100;

        public bool Validate(Student student)
        {
            return (DateTime.Now.Year - student.DoB.Year) >= 18;
        }
    }

    public class NameValidationRule : IValidationRule
    {
        public virtual int Order => 100;

        public bool Validate(Student student)
        {
            string pattern = @"^([A-Za-z]+)((\s[A-Za-z]+)+)?$";
            Regex regex = new Regex(pattern);
            var result = regex.Match(student.FullName);
            //var retval = (result != null) && result.Success;
            var retval = result.Success;
            return retval;
        }
    }


    public class Validation : IValidationService
    {
        public virtual bool validateStudent(Student student)
        {

            // scan all classes inheriting IValidationRule
            // Order by Order
            // call validate

            var builder = new ContainerBuilder();

            // The CLR won't load referenced assemblies until it is needed,
            // so this may not be very efficient for OS resources.
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyTypes(assembly)
                    .AssignableTo<IValidationRule>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .As<IValidationRule>();
            }

            var container = builder.Build();

            IEnumerable<IValidationRule> _validators = container.Resolve<IEnumerable<IValidationRule>>();
            foreach (var validator in _validators)
            {
                if (!validator.Validate(student))
                {
                    return false;
                }
            }

            return true;


            //builder.RegisterAssemblyTypes(validationRule)
            //    .AsImplementedInterfaces<>
            //AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            //    .Where(x => typeof(IValidationRule).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            //    .Select(x => x.Name).ToList();

            //return (
            //    validateName(student.FirstName) &&
            //    validateName(student.LastName) &&
            //    validateDoB(student.DoB) &&
            //    IsAgeEnough(student) &&
            //    IsGenderAllowed(student)
            //);
        }

        public virtual bool IsAgeEnough(Student student)
        {
            return (DateTime.Now.Year - student.DoB.Year) >= 18;
        }
        public virtual bool validateDoB(DateTime date)
        {
            // check year
            // 1753 is the minimum year in SQL Server
            if ((DateTime.Compare(date, DateTime.Now) > 0) || (date.Year < 1753))
            {
                return false;
            }
            return true;
        }

        protected virtual bool IsGenderAllowed(Student student)
        {
            return student.Gender == Gender.Male;
        }

        public virtual bool validateName(string name)
        {
            string pattern = @"^([A-Za-z]+)((\s[A-Za-z]+)+)?$";
            Regex regex = new Regex(pattern);
            var result = regex.Match(name);
            //var retval = (result != null) && result.Success;
            var retval = result.Success;
            return retval;
        }
    }
}