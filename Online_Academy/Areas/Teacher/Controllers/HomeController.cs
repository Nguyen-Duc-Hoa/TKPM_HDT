using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Academy.Models;

namespace Online_Academy.Areas.Teacher.Controllers
{
    public class HomeController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Teacher/Home
        public ActionResult Index()
        {
            int a = Convert.ToInt32(Session["userID"]);
            if ( a==0|| Session["userID"]==null|| Session["role"].ToString() != "Teacher")
            {
                return View("../Account/Login");
               
            }
            else
            {
                int? numcourse = db.getTotalCourse(a).FirstOrDefault();
                double? totalreveneu = db.getTotalReveneuAllCourses(a).FirstOrDefault();
                int? totalstudent= db.getTotalStudentAllCourse(a).FirstOrDefault();
                ViewBag.numcourse = numcourse;
                ViewBag.totalreveneu = Convert.ToInt32(totalreveneu);
                ViewBag.totalstudent = totalstudent;
                return View("Dashboard");
            }
            
        }
    }
}