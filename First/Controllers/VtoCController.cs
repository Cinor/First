using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First.Models;
using First.Models.ViewModels;

namespace First.Controllers
{
    public class VtoCController : Controller
    {
        // GET: VtoC
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 查詢字串-> ?name1=value1&name2=value2&....
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoQueryString()
        {
            ViewBag.id = int.Parse(Request.QueryString["id"]);
            return View();
        }

        /// <summary>
        /// "/{Controller}/{Action}/{id}"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DemoRouteData(int id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 簡單的Model Binding
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult BasicModelBinding(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        /// <summary>
        /// 經由ViewData.Model傳遞資料
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult BasicModelBindingByModel(string name)
        {
            ViewData.Model = name;
            return View();
        }

        /// <summary>
        /// FormCollection 在傳遞少量參數的好方法，參數一多就不適合使用了
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult DemoFormCollection(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Age = form["age"];
            return View();
        }

        /// <summary>
        /// 比較複雜的Model Binding
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public ActionResult PersonModelBinding(Person person)
        {
            return View(person);
        }

        /// <summary>
        /// 多Model的Model Binding
        /// </summary>
        /// <param name="man"></param>
        /// <param name="woman"></param>
        /// <returns></returns>
        public ActionResult MultiPersonModelBinding(Person man ,Person woman)
        {
            ViewBag.ManName = man.Name;
            ViewBag.ManAge = man.Age;

            ViewBag.WomanName = woman.Name;
            ViewBag.WomanAge = woman.Age;
            return View();
        }

        /// <summary>
        /// ViewModelModelBinding表單資料傳遞進Controller，再經由ShowViewModelModelBinding顯示至前端
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewModelModelBinding()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewModelModelBinding(PersonViewModel person)
        {
            return View("ShowViewModelModelBinding" , person);
        }

    }
}