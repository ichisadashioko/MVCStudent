using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentLib.Models;

namespace CAStudentMVC.Models
{
    public class CAStudentDBContext : DbContext
    {
        public DbSet<CAStudent> CAStudents { get; set; }
    }
}