using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace First.Models
{
    public static class Extension
    {
        public static string FromatForMoney(this int Value)
        {
            return Value.ToString("$###,###,##0");
        }

    }
}