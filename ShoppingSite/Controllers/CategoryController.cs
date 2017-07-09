using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace ShoppingSite.Controllers
{
    public class CategoryController : Controller
    {
        private O_BuyEntities _db = new O_BuyEntities();

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category cat, List<HttpPostedFileBase> images)
        {
            if (ModelState.IsValid)
            {
                var i = _db.Categories.FirstOrDefault(b => b.categoryName.ToLower() == cat.categoryName.ToLower());
                if (i == null)
                {
                    _db.Categories.Add(cat);
                    _db.SaveChanges();

                    if (images != null)
                    {
                        foreach (var image in images)
                        {
                            var filePath = Server.MapPath(ConfigurationManager.AppSettings["CategoryImagesPath"]);
                            var directory = new DirectoryInfo(filePath);
                            if (directory.Exists == false)
                            {
                                directory.Create();
                            }
                            string itemImgName = Guid.NewGuid() + image.FileName;
                            image.SaveAs(filePath + itemImgName);

                            CategoryImage img = new CategoryImage();
                            img.categoryId = cat.categoryId;
                            img.address = itemImgName;
                            _db.CategoryImages.Add(img);
                            _db.SaveChanges();
                        }
                        TempData["AddCategoryMessage"] = "Category Added Successfully !";
                    }
                }
            }
            return View();
        }

        public ActionResult DisplayAllCategories()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
    }
}