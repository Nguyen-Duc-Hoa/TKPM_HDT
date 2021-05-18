using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        public int pageSize = 3;
        public bool AuthorizeAdmin()
        {
            if (Session["role"].ToString() == "Admin")
            {
                return true;
            }
            return false;
        }
        // GET: Admin/Student
        public ActionResult Index(string txtSearch, int? page)
        {
            if (!AuthorizeAdmin())
            {
                return RedirectToAction("Login");
            }
            UsersClient client = new UsersClient();
            var data = client.findAll();

            if (!String.IsNullOrEmpty(txtSearch))
            {
                ViewBag.txtSearch = txtSearch;
                data = data.Where(x => x.name.Contains(txtSearch));
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
            int totalPage = data.Count();
            // tổng số trang cần hiển thị
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.users = data.OrderByDescending(x => x.id).Skip(start).Take(pageSize);
            return View();
        }
        [HttpPost]
        public ActionResult Approve(int idStudent)
        {
            if (!AuthorizeAdmin())
            {
                return RedirectToAction("Login");
            }
            try
            {
                var dbStudent = db.Users.Where(c => c.id == idStudent).FirstOrDefault();
                dbStudent.state = true;
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Fail");
            }
        }
        [HttpPost]
        public ActionResult Cancel(int idStudent)
        {
            if (!AuthorizeAdmin())
            {
                return RedirectToAction("Login");
            }
            try
            {
                var dbStudent = db.Users.Where(c => c.id == idStudent).FirstOrDefault();
                dbStudent.state = false;
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