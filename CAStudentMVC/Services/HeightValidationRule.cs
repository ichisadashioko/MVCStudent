using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;
using CAStudentMVC.Models;

namespace CAStudentMVC.Services
{
    public class HeightValidationRule : IValidationRule
    {
        public int Order => 5;

        public bool Validate(Student student)
        {
            if (typeof(CAStudent).IsAssignableFrom(student.GetType()))
            {
                CAStudent caStudent = (CAStudent)student;
                if (caStudent.Gender == Gender.Male && caStudent.Height >= 1.6 && caStudent.Age < 23)
                {
                    return true;
                }
                else if (caStudent.Gender == Gender.Female && caStudent.Height >= 1.55 && caStudent.Age < 21)
                {
                    return true;
                }
            }
            return false;
        }
    }
}