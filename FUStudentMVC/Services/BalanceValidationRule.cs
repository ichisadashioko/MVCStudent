
using StudentLib.Models;
using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace FUStudentMVC.Services
{
    public class BalanceValidationRule : IValidationRule
    {
        public int Order => 2;
        public virtual string Description => "Students must have more than 1 billion in their bank account.";

        public bool Validate(Student student)
        {
            return student.BankBalance >= 1_000_000_000m;
        }
    }
}