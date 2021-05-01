using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            // API chưa lấy subcategory khi lấy category
            List<Category> lstCategories = db.Categories.ToList();
            ViewBag.lstCategories = lstCategories;
            
            return View();
        }
    }
}