using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
namespace CAStudentMVC.Models
{
    public class CAStudent : Student
    {
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DoB.Year;
            }
        }
        public float Height { get; set; }
    }
}