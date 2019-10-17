using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentLib.Models;

namespace StudentLib.Repository
{
    public class StudentDBContext : DbContext
    {
        public DbSet<ValidatorModel> ValidatorModels { get; set; }
    }
}
