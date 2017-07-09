using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace ShoppingSite.Controllers
{
    public class MobileController : Controller
    {
        O_BuyEntities db = new O_BuyEntities();
        // GET: Mobile
        public ActionResult Index()
        {
            List<Item> list = db.Items.Include("itemImages").Where(x => x.Category.categoryName == "Smartphones")
                .ToList();
            return View(list);
        }
    }
}