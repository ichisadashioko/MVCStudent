using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;
using CAStudentMVC.Models;

namespace CAStudentMVC.Services
{
    public class EntryScoreValidationRule : CAValidationRule
    {
        public override int Order => 9;

        protected override bool ValidateStudent(CAStudent student)
        {
            return (student.EntryScore + student.BonusEntryScore) > 8.0f;
        }
    }
}