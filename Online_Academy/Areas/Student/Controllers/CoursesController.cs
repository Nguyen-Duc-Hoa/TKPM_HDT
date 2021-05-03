using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Academy.Models;
namespace Online_Academy.Areas.Student.Controllers
{
    public class CoursesController : Controller
    {
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Student/Courses
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult LoadCourse()
        {

            CourseClient CC = new CourseClient();
            ViewBag.Course = CC.GetAllCourses();
            if (Session["UserId"] != null)
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                ViewBag.Course = CC.GetCourseByUser(idUser);
            }
            return PartialView();
        }

        public ActionResult LoadCategories()
        {
            CategoriesClient CC = new CategoriesClient();
            ViewBag.Cate = CC.findAll();

            UpdateList_inline("All course", null);

            
            ViewBag.SubCate = db.Subcategories;

            return PartialView();
        }

        public ActionResult CourseDetail(int id)
        {

            return View();
        }

        public ActionResult CourseByType(int id)
        {
            CourseClient CC = new CourseClient();
            ViewBag.Course = db.Courses.Where(x => x.id_subcat == id);

            if (Session["UserId"] != null)
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                var AllCourse = CC.GetCourseByUser(idUser);
                ViewBag.Course = AllCourse.Where(x => x.id_subcat == id);
            }
            return PartialView();
        }

        public ActionResult General()
        {
            CourseClient CC = new CourseClient();
            ViewBag.Course = db.Courses;
            if (Session["UserId"] != null)
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                ViewBag.Course = CC.GetCourseByUser(idUser);
            }
            
            return PartialView("CourseByType");
        }

        
        public ActionResult UpdateList_inline(string var1, string var2)
        {
            List<string> list = new List<string>();
            list.Add(var1);
            if(var2 != null)
            {
                list.Add(var2);
            }
           

            ViewBag.list = list;
            return PartialView();
        }

        public bool Like(int idCourse)
        {
            DateTime date = DateTime.Now;
            if (Session["UserId"] != null)
            {
                int idStudent = Convert.ToInt32(Session["UserId"]);
                try
                {
                    db.sp_add_favorite(idStudent, idCourse, date);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public ActionResult RemoveLike (int idCourse)
        {
            try
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                if(idUser != 0)
                {
                    CourseClient CC = new CourseClient();
                    CC.RemoveLike(idUser, idCourse);
                }
            }
            catch
            {

            }
            return View();
        }
    }
}