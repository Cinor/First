using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using First.Models;
using First.Models.ViewModels;

namespace First.Controllers
{
    public class CtoVController : Controller
    {

        private NorthwindEntities db = new NorthwindEntities();

        // GET: CtoV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoViewData()
        {
            ViewData["Name"] = "Bruce";
            return View();
        }

        public ActionResult DemoViewBag()
        {
            // ViewData["Name"] = "Bruce";
            ViewBag["Name"] = "Bruce";
            return View();
        }

        public ActionResult DemoVDModel()
        {
            ViewBag.products = db.Products.ToList();
            return View();
        }

        public ActionResult DemoStronglytyped()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult DemoInput()
        {
            return View();
        }

        public ActionResult CheckInput(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                TempData["Error"] = "不得為空!";
                return RedirectToAction("DemoInput");
            }

            ViewBag.Name = name;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoTempData()
        {
            ViewData["Msg1"] = "From ViewData Message.";
            ViewBag.Msg2 = "From ViewBag Message.";
            TempData["Msg3"] = "From TempData Message.";
            return RedirectToAction("Redirect1");
        }

        public ActionResult Redirect1()
        {
            TempData["Msg4"] = TempData["Msg3"];
            return RedirectToAction("GetRedirectData");
        }

        public ActionResult GetRedirectData()
        {
            return View();
        }

        /// <summary>
        /// 利用TempData屬性跨Action方法的能力將Model資料由DemoTempDataProduct方法帶入到下一個Action
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoTempDataProduct()
        {
            TempData["products"] = db.Products.ToList();
            return Redirect("DemoTempDataKeep");
        }

        public ActionResult DemoTempDataKeep()
        {
            return View();
        }


        /// <summary>
        /// 多Model經過Include封裝成單一Model在傳遞至單一View顯示
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoInclude()
        {
            var products = db.Products
                            .Include(p => p.Category)
                            .Include(p => p.Supplier);

            return View(products.ToList());
        }


        /// <summary>
        /// 利用ViewBag中的SelectList傳遞DropDownList中要使用的清單項目
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoSelectList()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoMultiModelObject()
        {
            ViewBag.Author = "Bruce";
            ViewBag.Book = "ASP.Net MVC 5";
            ViewBag.Product = (from p in db.Products select p).Take(10).ToList();
            ViewBag.Category = (from c in db.Categories select c).Take(10).ToList();

            return View();
        }

        
        /// <summary>
        /// 為View專門訂製專屬的ViewModels已顯示資料
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoViewModel()
        {
            return View(new ProductCategoryViewModel()
            {   Name = "Bruce",
                Book = "ASP.Net MVC 5",
                Product = (from p in db.Products select p).Take(10).ToList(),
                Category = (from c in db.Categories select c).Take(10).ToList()
            });
        }

        /// <summary>
        /// Tuple 是有項目特定數目和序列的資料結構
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoTuple()
        {
            var products = db.Products.ToList();
            var categories = db.Categories.ToList();
            var suppliers = db.Suppliers.ToList();
            var tupleModel = new Tuple<List<Product>, List<Category>, List<Supplier>>(products, categories, suppliers);

            return View(tupleModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}