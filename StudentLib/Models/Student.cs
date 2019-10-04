
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudentLib.Models
{
    public enum Gender
    {
        Male,
        Female,
    }
    public class Student
    {
        public virtual int ID { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }

        [Display(Name = "Full Name")]
        public virtual string FullName { get { return $"{FirstName} {LastName}"; } }

        public virtual Gender Gender { get; set; }

        [Required, Display(Name = "Entry Score")]
        public virtual float EntryScore { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime DoB { get; set; }

        public virtual bool HasCriminalRecord { get; set; }
    }
}