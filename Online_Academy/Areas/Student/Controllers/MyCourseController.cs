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
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Student/MyCourse
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Course()
        {
            try
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                //Kieem tra dang nhap
                if(idUser != 0)
                {
                    
                    return View();
                }
                else
                {
                    //login
                    //return Content("<script language='javascript' type='text/javascript'>alert('Login now!');</script>");
                    Response.Write(@"<script language='javascript'>alert('Message: \n" + "Login now!" + " .');</script>");
                    //return Redirect("/Account/Login");
                }
                
            }
            catch
            {
                Response.Write(@"<script language='javascript'>alert('Message: \n" + "Login now!" + " .');</script>");
                return Redirect("/Account/Login");
            }
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult loadMyCourse(int idUser)
        {
            HistoriesClient HC = new HistoriesClient();
            //ViewBag.Course = HC.GetAllCourse(idUser);

            ViewBag.Course = db.sp_Course_bought(idUser);
            return PartialView("loadFCourse");
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

        public ActionResult LeftList()
        {
            return PartialView();
        }

        //complete course
        public ActionResult CompletedCourse()
        {
            try
            {
                int iduser = Convert.ToInt32(Session["UserId"]);
                if(iduser != 0)
                {

                }
            }
            catch
            {

            }
            return View();
        }

        public ActionResult Instructors()
        {
            TeachersClient TC = new TeachersClient();
            ViewBag.Teachers = TC.findAll();
            return View();
        }

        public ActionResult InstructorDetail(int id)
        {
            TeachersClient TC = new TeachersClient();
            ViewBag.Teachers = TC.find(id);
            DateTime datejoin = TC.find(id).date_join.Value;

            ViewBag.joinDate = datejoin.ToString("dd/MM/yyyy");
            return View();
        }

        
    }
}