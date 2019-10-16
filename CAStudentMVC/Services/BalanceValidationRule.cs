using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;
using CAStudentMVC.Models;

namespace CAStudentMVC.Services
{
    public class BalanceValidationRule : IValidationRule
    {
        public int Order => 15;
        public virtual string Description => $"Students must have more than {MinimalBalance / 10e6m} million in their bank account.";
        private readonly decimal MinimalBalance = 500_000_000m;
        public bool Validate(Student student)
        {
            return student.BankBalance >= 500_000_000m;
        }
    }
}