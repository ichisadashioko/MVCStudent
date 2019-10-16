
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StudentLib.Models;
using StudentLib.Services;
using BKStudentMVC.Models;
using StudentLib.Repository;

namespace BKStudentMVC.Services
{
    public class BKValidationService : ValidationService
    {
        public BKValidationService(IEnumerable<IValidationRule> validationRules, IRuleDataService validatorDataService) : base(validationRules, validatorDataService) { }

        protected override IEnumerable<Type> GetIgnoredRules()
        {
            return new List<Type>()
            {
                typeof(GenderValidationRule),
            };
        }
    }


}