using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace ShoppingSite.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        O_BuyEntities db = new O_BuyEntities();

        public ActionResult AddItem(int prodId, string URL)
        {
            if (Session["userId"] != null)
            {
                Card carditem = new Card();
                carditem.cardStatus = 1;
                carditem.productId = prodId;
                carditem.userId = Convert.ToInt32(Session["userId"]);
                db.Cards.Add(carditem);
                db.SaveChanges();
                TempData["Message"] = "Item Added to Cart !";
            }
            else
            {
                TempData["urlToReturn"] = Url.Content("~/Item/ShowItemDetail?itemId=" + prodId + "");
                TempData["Message"] = "Please SignIn to proceed !";
                return RedirectToAction("Login", "Account");
            }
            return Redirect(URL);
        }

        public ActionResult ShowCartItems()
        {
            if (Session["userId"] != null)
            {
                var user = Convert.ToInt32(Session["userId"]);
                List<Card> list = db.Cards.Include("Item").Where(x => x.cardStatus == 1 && x.userId == user).ToList();
                return View(list);
            }
            TempData["urlToReturn"] = Url.Content("~/Cart/ShowCartItems");
            TempData["Message"] = "Please SignIn to proceed !";
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ClearCart()
        {
            int userID = Convert.ToInt32(Session["userId"]);
            db.Cards.RemoveRange(db.Cards.Where(x => x.userId == userID));
            db.SaveChanges();
            TempData["ClearCartItemMessage"] = "Cart Items Cleared Successfully !";
            return RedirectToAction("ShowCartItems", "Cart");
        }

        public ActionResult ClearCartItem(int id)
        {
            int userID = Convert.ToInt32(Session["userId"]);
            db.Cards.Remove(db.Cards.FirstOrDefault(x => x.cartId == id));
            db.SaveChanges();
            TempData["ClearCartItemMessage"] = "Cart Item Cleared !";
            return RedirectToAction("ShowCartItems", "Cart");
        }
    }
}