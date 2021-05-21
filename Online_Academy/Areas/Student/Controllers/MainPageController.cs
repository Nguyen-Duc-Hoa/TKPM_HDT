using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Academy.Models;

namespace Online_Academy.Areas.Student.Controllers
{
    public class MainPageController : Controller
    {
        
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Student/MainPage

        
        public ActionResult Index()
        {
            Session["UserId"] = 1;
            return View();
        }

        public ActionResult LoadCourse()
        {
            CourseClient CC = new CourseClient();

            //ViewBag.Course = db.Courses;
            ViewBag.Course = CC.GetAllCourses();
            if (Session["UserId"] != null)
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                ViewBag.Course = CC.GetCourseByUser(idUser);
            }

            return PartialView();
        }
        public ActionResult Layout()
        {
            
            return View();
        }

        public ActionResult SubLayout()
        {
            return View();
        }

    }
}