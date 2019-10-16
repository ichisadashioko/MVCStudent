using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentLib.Models;
using StudentLib.Repository;

namespace BKStudentMVC.Models
{
    public class BKDBContext : StudentDBContext
    {
        public DbSet<BKStudent> Students { get; set; }
    }
}