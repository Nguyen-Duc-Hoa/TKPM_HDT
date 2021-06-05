using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        public int pageSize = 3;
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
        // GET: Admin/Teacher
        public ActionResult Index(string txtSearch, int? page)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            // get teachers, whose state is false (NOT USE API)
            List<User> listTeacher = db.Users.Where(t => t.Role1.role1 == "Teacher").ToList();

            if (!String.IsNullOrEmpty(txtSearch))
            {
                ViewBag.txtSearch = txtSearch;
                listTeacher = listTeacher.Where(c => c.name.Contains(txtSearch)).ToList();
            }

            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }

            int start = (int)(page - 1) * pageSize;

            ViewBag.pageCurrent = page;
            int totalPage = listTeacher.Count();
            // tổng số trang cần hiển thị
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.lstTeacher = listTeacher.OrderByDescending(x => x.id).Skip(start).Take(pageSize);

            return View();
        }
        [HttpPost]
        // accept account of teacher => teacher can upload course
        public ActionResult Approve(int idTeacher)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                var dbTeacher = db.Users.Where(t => t.id == idTeacher).FirstOrDefault();
                dbTeacher.state = true;
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Fail");
            }
        }
        [HttpPost]
        // reject account of teacher => remove account from database
        public ActionResult Cancel(int idTeacher)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                var dbTeacher = db.Users.Where(t => t.id == idTeacher).FirstOrDefault();
                dbTeacher.state = false;
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Fail");
            }
        }
    }
}