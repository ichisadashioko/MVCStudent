using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using StudentLib.Services;

namespace StudentMVC2.Services
{
    public class HSValidationService : ValidationService
    {
        public override bool ValidateStudent(Student student)
        {
            return base.ValidateStudent(student);
        }
    }
}