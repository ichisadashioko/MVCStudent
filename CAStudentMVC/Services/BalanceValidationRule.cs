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

        public bool Validate(Student student)
        {
            return student.BankBalance >= 500_000_000m;
        }
    }
}