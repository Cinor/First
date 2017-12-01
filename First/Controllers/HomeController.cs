using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First.Models;
using First.Filters;
using System.Web.Mvc.Filters;

namespace First.Controllers
{
    public class HomeController : Controller
    {
        CRUD_Orders _Orders = new CRUD_Orders();

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            base.OnAuthentication(filterContext);
        }

        protected override void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            base.OnAuthenticationChallenge(filterContext);
        }

        [Mvc5Authv1]
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index(Customer i ,int k)
        //{
        //    _Orders.Create(i);
        //    k.FromatForMoney();

        //    return View();
        //}

        [Mvc5Authv2]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}