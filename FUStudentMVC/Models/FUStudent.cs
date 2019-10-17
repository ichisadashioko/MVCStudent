using StudentLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using StudentLib.Repository;

namespace FUStudentMVC.Models
{
    public class FUStudent : Student
    {
        public int Credits { get; set; }
    }
    public class FUDBContext : DbContext
    {
        public DbSet<FUStudent> Students { get; set; }
    }
}