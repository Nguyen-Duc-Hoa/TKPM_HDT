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
        public bool AuthorizeAdmin()
        {
            if (Session["role"] == null)
            {
                return false;
            }
            if (Session["role"].ToString() == "Admin")
            {
                return true;
            }
            return false;
        }
        public ActionResult Index()
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            // API chưa lấy subcategory khi lấy category
            List<Category> lstCategories = db.Categories.ToList();
            ViewBag.lstCategories = lstCategories;
            
            return View();
        }
        public ActionResult EditSubcategory(int idSubcate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbSubcate = db.Subcategories.Where(s => s.id == idSubcate).FirstOrDefault();
                return View(dbSubcate);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult EditSubcategory(Subcategory sub)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbSubcate = db.Subcategories.Where(s => s.subname.Trim() == sub.subname.Trim()).FirstOrDefault();
                var dbCate = db.Categories.Where(s => s.name.Trim() == sub.subname.Trim()).FirstOrDefault();
                if(dbSubcate != null || dbCate != null)
                {
                    ViewBag.message = "Tên này đã được sử dụng";
                    return View("Error");
                }
                var dbSub = db.Subcategories.Where(s => s.id == sub.id).FirstOrDefault();
                dbSub.subname = sub.subname.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult AddSubcategory(int idCate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            Subcategory sub = new Subcategory() { id_cat = idCate };
            return View(sub);
        }
        [HttpPost]
        public ActionResult AddSubcategory(Subcategory sub)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbSubcate = db.Subcategories.Where(s => s.subname.Trim() == sub.subname.Trim()).FirstOrDefault();
                var dbCate = db.Categories.Where(s => s.name.Trim() == sub.subname.Trim()).FirstOrDefault();
                if (dbSubcate != null || dbCate != null)
                {
                    ViewBag.message = "Tên này đã được sử dụng";
                    return View("Error");
                }
                db.Subcategories.Add(sub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult DeleteSubcategory(int idSubcate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbSub = db.Subcategories.Where(s => s.id == idSubcate).FirstOrDefault();
                if(dbSub.Courses.Count != 0)
                {
                    ViewBag.message = "Có khóa học tham chiếu đến subcategory";
                    return View("Error");
                }
                db.Subcategories.Remove(dbSub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult AddCategory()
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category cate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbSubcate = db.Subcategories.Where(s => s.subname.Trim() == cate.name.Trim()).FirstOrDefault();
                var dbCategory = db.Categories.Where(c => c.name.Trim() == cate.name.Trim()).FirstOrDefault();
                if (dbSubcate != null || dbCategory != null)
                {
                    ViewBag.message = "Tên này đã được sử dụng";
                    return View("Error");
                }

                db.Categories.Add(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult DeleteCategory(int idCate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbCate = db.Categories.Where(c => c.id == idCate).FirstOrDefault();
                if(dbCate.Subcategories.Count != 0)
                {
                    ViewBag.message = "Category vẫn còn subcategory";
                    return View("Error");
                }
                db.Categories.Remove(dbCate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult EditCategory(int idCate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbCate = db.Categories.Where(c => c.id == idCate).FirstOrDefault();
                return View(dbCate);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult EditCategory(Category cate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("/Account/Login");
            }
            try
            {
                var dbSubcate = db.Subcategories.Where(s => s.subname.Trim() == cate.name.Trim()).FirstOrDefault();
                var dbCategory = db.Categories.Where(c => c.name.Trim() == cate.name.Trim()).FirstOrDefault();
                if(dbSubcate != null || dbCategory != null)
                {
                    ViewBag.message = "Tên này đã được sử dụng";
                    return View("Error");
                }

                var dbCate = db.Categories.Where(c => c.id == cate.id).FirstOrDefault();
                dbCate.name = cate.name.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}