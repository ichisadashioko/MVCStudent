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