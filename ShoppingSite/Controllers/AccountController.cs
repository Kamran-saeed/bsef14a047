using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using ShoppingSite.Models;

namespace ShoppingSite.Controllers
{
    public class AccountController : Controller
    {
        O_BuyEntities db = new O_BuyEntities();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel u,string url)
        {
            if (ModelState.IsValid)
            {
                var data = db.Users.FirstOrDefault(x => x.Login.Equals(u.Login) && x.Password.Equals(u.Password));
                if (data != null)
                {
                    if(data.Type == 1)
                        return RedirectToAction("Menu", "AdminMenu");
                    else
                    {
                        Session["userId"] = data.Id.ToString();
                        Session["userName"] = data.Name;
                        Session["userPassword"] = data.Password;
                        if (url == null)
                        {
                            url = Url.Content("~/Home/Index");
                        }
                        return Redirect(url);
                    }
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                u.Type = 2;
                db.Users.Add(u);
                db.SaveChanges();
                TempData["MessageFromRegistration"] = "Congratulation, Registration Successfull !";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Response.Cookies.Clear();
            Session.RemoveAll();

            Session["userId"] = null;
            Session["userName"] = null;
            Session["userPassword"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}