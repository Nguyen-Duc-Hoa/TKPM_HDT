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
        public ActionResult Index()
        {
            CourseClient client = new CourseClient();
            // Modify API to get course available
            List<Course> lstCourses = db.Courses.Where(c => c.state == true).ToList();
            ViewBag.lstCourses = lstCourses;
            return View();
        }
    }
}