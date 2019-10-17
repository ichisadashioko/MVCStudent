
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
        public virtual string Description => $"Only allow student whose Entry Score is over {MinimalScore:0.00}.";
        private readonly float MinimalScore = 7f;
        public bool Validate(Student student)
        {
            return student.EntryScore > MinimalScore;
        }
    }
}