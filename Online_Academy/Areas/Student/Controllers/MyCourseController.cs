using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Student.Controllers
{
    public class MyCourseController : Controller
    {
        // GET: Student/MyCourse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FavoriteCourse()
        {  
            return View();
        }

        public ActionResult loadFCourse()
        {
            try
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                if (idUser != 0)
                {
                    CourseClient CC = new CourseClient();
                    var allCourse = CC.GetCourseByUser(idUser);
                    ViewBag.Course = allCourse.Where(x => x.id_student == idUser);
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ex = ex.ToString();
                return View();
            }
            return View();
        }
    }
}