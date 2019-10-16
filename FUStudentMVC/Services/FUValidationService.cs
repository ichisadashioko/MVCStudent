
using StudentLib.Models;
using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace FUStudentMVC.Services
{
    public class FUValidationService : ValidationService
    {

        public FUValidationService(IEnumerable<IValidationRule> validationRules, IRuleDataService validatorDataService) : base(validationRules, validatorDataService) { }

        protected override IEnumerable<Type> GetIgnoredRules()
        {
            return new List<Type>()
            {
                typeof(GenderValidationRule),
                typeof(NameValidationRule),
            };
        }
    }
}