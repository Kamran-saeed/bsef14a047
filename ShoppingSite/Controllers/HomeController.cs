using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace ShoppingSite.Controllers
{
    public class HomeController : Controller
    {
        O_BuyEntities db = new O_BuyEntities();

        public ActionResult Index()
        {
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
        public ActionResult Category()
        {
            List<Category> list = db.Categories.Include("CategoryImages").ToList();
            return View(list);
        }
        public ActionResult OpenController(int catId)
        {
            var firstOrDefault = db.Categories.FirstOrDefault(x => x.categoryId == catId);
            if (firstOrDefault != null)
            {
                string name = firstOrDefault.categoryName;
                if (name == "Smartphones")
                {
                    return RedirectToAction("Index", "Mobile");
                }
                else if (name == "Men Fashion")
                {
                    return RedirectToAction("Index", "Fashion");
                }
                else if (name == "Women Fashion")
                {
                    return RedirectToAction("Index", "Women");
                }
            }
            return RedirectToAction("Category", "Home");
        }
    }
}