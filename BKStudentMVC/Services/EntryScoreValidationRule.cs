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
        public virtual string Description => "Only allow student whose Entry Score is over 7.5.";

        public bool Validate(Student student)
        {
            var totalScore = student.EntryScore + student.BonusEntryScore;
            Console.WriteLine($"totalScore: {totalScore}");
            var retval = totalScore > 7.5f;
            return retval;
        }
    }
}