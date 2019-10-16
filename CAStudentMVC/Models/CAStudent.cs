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

        public static readonly float PARENT_IN_SERVICE_BONUS = 0.2f;
        public static readonly float MOUNTAINOUS_BONUS = 0.2f;

        public override float BonusEntryScore
        {
            get
            {
                float retval = 0;
                if (WasParentInService)
                {
                    retval += PARENT_IN_SERVICE_BONUS;
                }
                if (Province.IsMountainous())
                {
                    retval += MOUNTAINOUS_BONUS;
                }
                return retval;
            }
        }
    }
}