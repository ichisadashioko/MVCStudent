using StudentLib.Models;
using StudentLib.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib.Services
{
    public interface IRuleDataService
    {
        IEnumerable<ValidatorModel> GetRules();
    }
    public class ValidatorDataService : IRuleDataService
    {
        private readonly StudentDBContext _db;
        public ValidatorDataService(StudentDBContext db)
        {
            _db = db;
        }

        public IEnumerable<ValidatorModel> GetRules()
        {
            return _db.ValidatorModels.ToList();
        }
    }
}
