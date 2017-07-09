using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace ShoppingSite.Common
{
    public class DropDown
    {
        static O_BuyEntities db = new O_BuyEntities();
        public static List<Category> getCategory()
        {
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
    }
}