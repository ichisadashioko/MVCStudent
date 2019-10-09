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

        public override float BonusEntryScore
        {
            get
            {
                float retval = 0;
                if (WasParentInService)
                {
                    retval += 0.2f;
                }
                if (Province.IsMountainous())
                {
                    retval += 0.2f;
                }
                return retval;
            }
        }
    }
}