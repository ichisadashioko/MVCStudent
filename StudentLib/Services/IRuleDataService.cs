using StudentLib.Models;
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
}
