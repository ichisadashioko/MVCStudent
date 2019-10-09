using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;
using CAStudentMVC.Models;

namespace CAStudentMVC.Services
{
    public class HeightValidationRule : CAValidationRule
    {
        public override int Order => 5;

        protected override bool ValidateStudent(CAStudent student)
        {
            if (student.Gender == Gender.Male && student.Height >= 1.6 && student.Age < 23)
            {
                return true;
            }
            else if (student.Gender == Gender.Female && student.Height >= 1.55 && student.Age < 21)
            {
                return true;
            }
            return false;
        }
    }
}