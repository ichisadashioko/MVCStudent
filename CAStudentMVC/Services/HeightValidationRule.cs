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
        public override string Description => $"Male student must be younger than {MaleMaxAge} and taller than {MaleMinHeight:0.00}. Female student must be younger than {FemaleMaxAge} and taller than {FemaleMinHeight:0.00}.";

        private readonly int MaleMaxAge = 23;
        private readonly float MaleMinHeight = 1.6f;

        private readonly int FemaleMaxAge = 21;
        private readonly float FemaleMinHeight = 1.55f;

        protected override bool ValidateStudent(CAStudent student)
        {
            if (student.Gender == Gender.Male && student.Height >= MaleMinHeight && student.Age < MaleMaxAge)
            {
                return true;
            }
            else if (student.Gender == Gender.Female && student.Height >= FemaleMinHeight && student.Age < FemaleMaxAge)
            {
                return true;
            }
            return false;
        }
    }
}