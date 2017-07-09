using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using ShoppingSite.Common;

namespace ShoppingSite.Controllers
{
    public class ItemController : Controller
    {
        O_BuyEntities db = new O_BuyEntities();
        // GET: Item
        public ActionResult AddItem()
        {
            ViewBag.Categories = DropDown.getCategory();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Additem(Item item, List<HttpPostedFileBase> images)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Items.Add(item);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                }

                if (images != null)
                {
                    foreach (var image in images)
                    {
                        var filePath = Server.MapPath(ConfigurationManager.AppSettings["ItemImagesPath"]);
                        var directory = new DirectoryInfo(filePath);
                        if (directory.Exists == false)
                        {
                            directory.Create();
                        }
                        string itemImgName = Guid.NewGuid() + image.FileName;
                        image.SaveAs(filePath + itemImgName);

                        itemImage img = new itemImage();
                        img.itemId = item.id;
                        img.address = itemImgName;
                        db.itemImages.Add(img);
                        db.SaveChanges();
                    }
                    ViewBag.Message = "True";
                }
            }
            ViewBag.Categories = DropDown.getCategory();
            return View();
        }

        public ActionResult ShowItemDetail(int itemId)
        {
            Item item = db.Items.Include("itemImages").FirstOrDefault(it => it.id == itemId);
            return View(item);
        }
    }
}