
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
}