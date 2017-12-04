using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace First.Models
{
    public class PasswordUtility
    {
        public static bool PasswordLength(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            else
            {
                if (0 - Convert.ToInt32(Regex.IsMatch(password, "[a-z]")) - 
                    Convert.ToInt32(Regex.IsMatch(password, "[A-Z]")) -
                    Convert.ToInt32(Regex.IsMatch(password, "\\d")) -
                    Convert.ToInt32(Regex.IsMatch(password, ".{10,}")) <= -2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}