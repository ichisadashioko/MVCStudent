using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentLib.Models;
using StudentLib.Repository;

namespace CAStudentMVC.Models
{
    public class CAStudentDBContext : StudentDBContext
    {
        public DbSet<CAStudent> CAStudents { get; set; }
    }
}