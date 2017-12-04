using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First.Models;

namespace First.Controllers
{
    public class PasswordLengthController : Controller
    {
        // GET: PasswordLength
        public ActionResult DemoLength()
        {
            return View();
        }

        public string LengthCheck(string pw)
        {
            if (Request.IsAjaxRequest())
            {
                bool status = PasswordUtility.PasswordLength(pw);
                string result = status ? "通過" : "不通過";
                return result;
            }
            else
            {
                return "非AJAX請求!";
            }
        }

    }
}