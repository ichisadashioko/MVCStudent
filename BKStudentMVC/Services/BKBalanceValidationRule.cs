using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;

namespace BKStudentMVC.Services
{
    public class BKBalanceValidationRule : IValidationRule
    {
        public int Order => 26;
        public virtual string Description => "Students who are from Hanoi must have more than 500 million in their bank account. Otherwise, they must have more than 300 million in their bank account";

        public bool Validate(Student student)
        {
            if (student.Province == Province.HaNoi && student.BankBalance > 500_000_000m)
            {
                return true;
            }
            else if (student.Province != Province.HaNoi && student.BankBalance > 300_000_000m)
            {
                return true;
            }
            return false;
        }
    }
}