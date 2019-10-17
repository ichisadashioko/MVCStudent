using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StudentLib.Models;

namespace StudentLib.Services
{
    public interface IValidationRule
    {
        int Order { get; }
        string Description { get; }
        bool Validate(Student student);
    }  

    public class GenderValidationRule : IValidationRule
    {
        public virtual int Order => 200;
        public virtual string Description => "Only allow male students.";

        public bool Validate(Student student)
        {
            return student.Gender == Gender.Male;
        }
    }

    public class AgeValidationRule : IValidationRule
    {
        public virtual int Order => 13;
        public virtual string Description => "Only allow student whose age is over 18.";

        public bool Validate(Student student)
        {
            return (DateTime.Now.Year - student.DoB.Year) >= 18;
        }
    }

    public class NameValidationRule : IValidationRule
    {
        public virtual int Order => 100;
        public virtual string Description => "Only allow student whose name only contains alphabet characters.";

        public bool Validate(Student student)
        {
            string pattern = @"^([A-Za-z]+)((\s[A-Za-z]+)+)?$";
            Regex regex = new Regex(pattern);
            var result = regex.Match(student.FullName);
            var retval = result.Success;
            return retval;
        }
    }

}
