
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StudentLib.Models;
using StudentLib.Services;
using BKStudentMVC.Models;

namespace BKStudentMVC.Services
{

    public class ValidatorDataService : IRuleDataService
    {
        private readonly BKDBContext _db;
        public ValidatorDataService()
        {
            _db = new BKDBContext();
        }

        public IEnumerable<ValidatorModel> GetRules()
        {
            return _db.ValidatorModels.ToList();
        }
    }
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