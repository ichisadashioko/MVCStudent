using StudentLib.Models;
using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FUStudentMVC.Services
{
    public class FURuleDataService : IRuleDataService
    {
        public IEnumerable<ValidatorModel> GetRules()
        {
            var rules = new List<ValidatorModel>() {
                new ValidatorModel()
                {
                    Active=false,
                    FullName=typeof(GenderValidationRule).FullName,
                },
                new ValidatorModel()
                {
                    Active=true,
                    FullName=typeof(ForeignNameValidationRule).FullName,
                },
                new ValidatorModel()
                {
                    Active=true,
                    FullName=typeof(BalanceValidationRule).FullName,
                },
                new ValidatorModel()
                {
                    Active=true,
                    FullName=typeof(EntryScoreValidationRule).FullName,
                },
            };

            return rules;
        }
    }
}