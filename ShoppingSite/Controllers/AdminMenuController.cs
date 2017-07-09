using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingSite.Controllers
{
    public class AdminMenuController : Controller
    {
        // GET: AdminMenu
        public ActionResult Menu()
        {
            return View();
        }
    }
}