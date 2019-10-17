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
        /// Ignored rules by the programmer. Supplied via overriding `GetIgnoredRules()`.
        /// </summary>
        private readonly IEnumerable<Type> _ignoredRules;
        /// <summary>
        /// 
        /// </summary>
        protected readonly IRuleDataService _validatorDataService;

        public ValidationService(IEnumerable<IValidationRule> validationRules, IRuleDataService validatorDataService)
        {
            _validatorDataService = validatorDataService;
            _ignoredRules = GetIgnoredRules();
            _validationRules = GetEnabledValidators(validationRules);
            Debug.WriteLine($"[{this.GetType().FullName}] _validationRules.Count: {_validationRules.Count()}");
        }

        private IEnumerable<IValidationRule> GetEnabledValidators(IEnumerable<IValidationRule> validationRules)
        {
            IEnumerable<IValidationRule> retval = null;
            Debug.WriteLine($"[{this.GetType().FullName}.GetEnabledValidators] validationRules.Count: {validationRules.Count()}");
            if (_validatorDataService != null)
            {
                IEnumerable<ValidatorModel> validators = _validatorDataService.GetRules().Where(x => x.InEffect);

                retval = validationRules.Where(r => validators.Any(v => (v.FullName.Trim().Equals(r.GetType().FullName))));
            }
            else if (_ignoredRules != null && _ignoredRules.Any())
            {
                retval = validationRules.Where(x => !_ignoredRules.Any(t => t.Equals(x.GetType())));
            }
            else
            {
                retval = validationRules;
            }
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

        protected virtual IEnumerable<Type> GetIgnoredRules()
        {
            return null;
        }
    }
}