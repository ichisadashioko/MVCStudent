using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace StudentMVC.HelperServices
{
    public class Validation
    {
        public virtual bool validateDoB(DateTime DoB)
        {
            // check year
            // 1753 is the minimum year in SQL Server
            if ((DateTime.Compare(DoB, DateTime.Now) > 0) || (DoB.Year < 1753))
            {
                return false;
            }
            return true;
        }
        public virtual bool validateName(string name)
        {
            string pattern = @"^([A-Za-z]+)((\s[A-Za-z]+)+)?$";
            Regex regex = new Regex(pattern);
            var result = regex.Match(name);
            //var retval = (result != null) && result.Success;
            var retval = result.Success;
            return retval;
        }
    }
}