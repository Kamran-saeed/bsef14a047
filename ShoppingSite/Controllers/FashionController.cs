using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace ShoppingSite.Controllers
{
    public class FashionController : Controller
    {
        O_BuyEntities db = new O_BuyEntities();

        public ActionResult Index()
        {
            List<Item> list = db.Items.Include("itemImages").Where(x => x.Category.categoryName == "Men Fashion")
                .ToList();
            return View(list);
        }
    }
}