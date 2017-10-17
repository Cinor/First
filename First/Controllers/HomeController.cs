using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First.Models;

namespace First.Controllers
{
    public class HomeController : Controller
    {
        CRUD_Orders _Orders = new CRUD_Orders();

        public ActionResult Index(Table i ,int k)
        {
            _Orders.Create(i);
            k.FromatForMoney();

            return View();
        }

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