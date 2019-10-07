﻿using StudentLib.Models;
using StudentLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Services;
using System.Diagnostics;

namespace CAStudentMVC.Services
{
    public class BackgroundValidationRule : IValidationRule
    {
        public int Order => 0;

        public bool Validate(Student student)
        {
            return !student.HasCriminalRecord;
        }
    }
    public class CAValidationService : ValidationService
    {
    }
}