
using StudentLib.Models;
using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace FUStudentMVC.Services
{
    public class ForeignNameValidationRule : IValidationRule
    {
        public int Order => 4;
        public bool Validate(Student student)
        {
            string pattern = @"^([A-Za-z\p{L}]+)((\s[A-Za-z\p{L}]+)+)?$";
            Regex regex = new Regex(pattern);
            var result = regex.Match(student.FullName);
            var retval = result.Success;
            return retval;
        }
    }
    public class EntryScoreValidationRule : IValidationRule
    {
        public int Order => 1;

        public bool Validate(Student student)
        {
            return student.EntryScore > 7.0;
        }
    }
    public class FUValidationService : ValidationService
    {
        protected override IEnumerable<Type> GetIgnoredRules()
        {
            return new List<Type>()
            {
                typeof(GenderValidationRule)
            };
        }
    }
}