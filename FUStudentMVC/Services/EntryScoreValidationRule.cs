
using StudentLib.Models;
using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace FUStudentMVC.Services
{
    public class EntryScoreValidationRule : IValidationRule
    {
        public int Order => 1;
        public virtual string Description => "Only allow student whose Entry Score is over 7.";

        public bool Validate(Student student)
        {
            return student.EntryScore > 7.0;
        }
    }
}