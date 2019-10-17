using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;
using CAStudentMVC.Models;

namespace CAStudentMVC.Services
{
    public abstract class CAValidationRule : IValidationRule
    {
        public virtual int Order => throw new NotImplementedException();
        public virtual string Description => "Only available for CAStudent.";

        public virtual bool Validate(Student student)
        {
            if (IsAppliable(student))
            {
                CAStudent caStudent = (CAStudent)student;
                return ValidateStudent(caStudent);
            }

            return false;
        }

        protected abstract bool ValidateStudent(CAStudent student);

        protected bool IsAppliable(Student student)
        {
            return typeof(CAStudent).IsAssignableFrom(student.GetType());
        }
    }
}