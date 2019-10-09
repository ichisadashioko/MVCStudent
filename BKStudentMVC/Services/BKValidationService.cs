
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StudentLib.Models;
using StudentLib.Services;
namespace BKStudentMVC.Services
{
    public class EntryScoreValidationRule : IValidationRule
    {
        public int Order => 1;

        public bool Validate(Student student)
        {
            return student.EntryScore > 7.5;
        }
    }
    public class BKValidationService : ValidationService
    {
        protected override IEnumerable<Type> GetIgnoredRules()
        {
            return new List<Type>()
            {
                typeof(GenderValidationRule),
            };
        }
    }
}