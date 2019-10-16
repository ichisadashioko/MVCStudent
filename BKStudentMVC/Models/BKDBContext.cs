using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentLib.Models;

namespace BKStudentMVC.Models
{
    public class BKDBContext : DbContext
    {
        public DbSet<RuleModel> RuleModels { get; set; }
        public DbSet<BKStudent> Students { get; set; }
    }
}