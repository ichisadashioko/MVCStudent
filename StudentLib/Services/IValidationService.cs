using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentLib.Models;

namespace StudentLib.Services
{
    public interface IValidationService
    {
        bool ValidateStudent(Student student);
    }
}
