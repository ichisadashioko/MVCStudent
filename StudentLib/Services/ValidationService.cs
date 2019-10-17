using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentLib.Models;

namespace StudentLib.Services
{
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// All `IValidationRule` after being filtered.
        /// </summary>
        private readonly IEnumerable<IValidationRule> _validationRules;
        /// <summary>
        /// 
        /// </summary>
        protected readonly IRuleDataService _validatorDataService;

        public ValidationService(IEnumerable<IValidationRule> validationRules, IRuleDataService validatorDataService)
        {
            _validatorDataService = validatorDataService;
            _validationRules = GetEnabledValidators(validationRules);

            Debug.WriteLine($"[{this.GetType().FullName}] _validationRules.Count: {_validationRules.Count()}");
        }

        private IEnumerable<IValidationRule> GetEnabledValidators(IEnumerable<IValidationRule> validationRules)
        {
            Debug.WriteLine($"[{this.GetType().FullName}.GetEnabledValidators] validationRules.Count: {validationRules.Count()}");

            IEnumerable<ValidatorModel> validators = _validatorDataService.GetRules().Where(x => x.InEffect);

            Debug.WriteLine(validators.Count());

            var retval = validationRules.Where(r => validators.Any(v => (v.FullName.Trim().Equals(r.GetType().FullName))));
            retval = retval.OrderBy(x => x.Order);

            return retval;
        }

        public virtual bool ValidateStudent(Student student)
        {
            Debug.WriteLine($"[{this.GetType().FullName}.ValidateStudent] Start to validate {student.GetType().FullName}");

            if (_validationRules == null || !_validationRules.Any())
            {
                return true;
            }

            foreach (var validationRule in _validationRules)
            {
                Debug.WriteLine($"[{this.GetType().FullName}.ValidateStudent] Using {validationRule.GetType().FullName} to validate");

                if (!validationRule.Validate(student))
                {
                    Debug.WriteLine($"[{this.GetType().FullName}.ValidateStudent] Failed validation at {validationRule.GetType().FullName}");
                    return false;
                }
            }
            return true;
        }
    }
}