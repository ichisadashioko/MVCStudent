using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;

namespace BKStudentMVC.Services
{
    public class EntryScoreValidationRule : IValidationRule
    {
        public int Order => 1;

        public bool Validate(Student student)
        {
            return student.EntryScore > 7.5;
        }
    }
}