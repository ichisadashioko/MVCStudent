﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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

        [Display(Name = "Has Criminal Record")]
        public virtual bool HasCriminalRecord { get; set; }

        public virtual Province Province { get; set; }

        [Display(Name = "Bank Balance")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public virtual decimal BankBalance { get; set; }

    public virtual float BonusEntryScore
        {
            get { return 0; }
        }

        public override string ToString()
        {
            Type objType = this.GetType();
            PropertyInfo[] propertyInfoList = objType.GetProperties();
            StringBuilder result = new StringBuilder();

            foreach (var propertyInfo in propertyInfoList)
            {
                result.Append($"{propertyInfo.Name}={propertyInfo.GetValue(this)}, ");
            }

            return result.ToString();
        }
    }
}