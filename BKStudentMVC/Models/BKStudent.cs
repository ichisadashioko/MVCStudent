using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BKStudentMVC.Models
{
    public class BKStudent : Student
    {
        [Display(Name = "Undergraduate Years")]
        public int UndergraduateYears { get; set; }

        public override float BonusEntryScore
        {
            get
            {
                float retval = 0;
                if (this.Province != Province.HaNoi)
                {
                    retval += 0.1f;
                }
                Console.WriteLine($"BonusEntryScore: {retval}");
                return retval;
            }
        }
    }
    public class BKStudentDBContext : DbContext
    {
        public DbSet<BKStudent> Students { get; set; }
    }
}