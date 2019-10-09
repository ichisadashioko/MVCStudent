
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StudentLib.Models;
using StudentLib.Services;

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
    }
}