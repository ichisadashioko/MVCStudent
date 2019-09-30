using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace StudentMVC.HelperServices
{
    public class Validation
    {
        public static bool validateDoB(DateTime DoB)
        {
            // check year
            if (DateTime.Compare(DoB, DateTime.Now) > 0)
            {
                return false;
            }
            return true;
        }
        public static bool validateName(string name)
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