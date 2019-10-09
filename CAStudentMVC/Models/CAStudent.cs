using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLib.Models;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Was Parent in Service")]
        public bool WasParentInService { get; set; }
    }
}