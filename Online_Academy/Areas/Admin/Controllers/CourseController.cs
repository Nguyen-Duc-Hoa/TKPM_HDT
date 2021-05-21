using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Admin/Course
        public int pageSize = 1;

        public bool AuthorizeAdmin()
        {
            if(Session["role"].ToString() == "Admin")
            {
                return true;
            }
            return false;
        }
        public ActionResult Index(string txtSearch, int? page)
        {
            if(!AuthorizeAdmin())
            {
                return RedirectToAction("Login");
            }
            CourseClient client = new CourseClient();
            // Modify API to get course available
            List<Course> lstCourses = db.Courses.ToList();

            if (!String.IsNullOrEmpty(txtSearch))
            {
                ViewBag.txtSearch = txtSearch;
                lstCourses = lstCourses.Where(c => c.name.Contains(txtSearch)).ToList();
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
            int totalPage = lstCourses.Count();
            // tổng số trang cần hiển thị
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);
            ViewBag.numSize = numSize;
            ViewBag.courses = lstCourses.OrderByDescending(x => x.id).Skip(start).Take(pageSize);

            return View();
        }
        [HttpPost]
        public ActionResult Approve(int idCourse)
        {
            if (!AuthorizeAdmin())
            {
                return RedirectToAction("Login");
            }
            try
            {
                var dbCourse = db.Courses.Where(c => c.id == idCourse).FirstOrDefault();
                dbCourse.state = true;
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Fail");
            }
        }
        [HttpPost]
        public ActionResult Cancel(int idCourse)
        {
            if (!AuthorizeAdmin())
            {
                return RedirectToAction("Login");
            }
            try
            {
                var dbCourse = db.Courses.Where(c => c.id == idCourse).FirstOrDefault();
                dbCourse.state = false;
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