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
                return Redirect("Account/Login");
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
                return Redirect("Account/Login");
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
                return Redirect("Account/Login");
            }
            try
            {
                var dbSub = db.Subcategories.Where(s => s.id == sub.id).FirstOrDefault();
                dbSub.subname = sub.subname.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                return RedirectToAction("Index");
            }
        }
        public ActionResult AddSubcategory(int idCate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            Subcategory sub = new Subcategory() { id_cat = idCate };
            return View(sub);
        }
        [HttpPost]
        public ActionResult AddSubcategory(Subcategory sub)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                db.Subcategories.Add(sub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteSubcategory(int idSubcate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                var dbSub = db.Subcategories.Where(s => s.id == idSubcate).FirstOrDefault();
                db.Subcategories.Remove(dbSub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                return RedirectToAction("Index");
            }
        }
        public ActionResult AddCategory()
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category cate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                db.Categories.Add(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteCategory(int idCate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                var dbCate = db.Categories.Where(c => c.id == idCate).FirstOrDefault();
                db.Categories.Remove(dbCate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                return RedirectToAction("Index");
            }
        }
        public ActionResult EditCategory(int idCate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                var dbCate = db.Categories.Where(c => c.id == idCate).FirstOrDefault();
                return View(dbCate);
            }
            catch
            {
                Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult EditCategory(Category cate)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                var dbCate = db.Categories.Where(c => c.id == cate.id).FirstOrDefault();
                dbCate.name = cate.name.Trim();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                return RedirectToAction("Index");
            }
        }
    }
}