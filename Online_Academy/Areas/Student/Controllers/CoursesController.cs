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
        // GET: Student/Courses
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult LoadCourse()
        {
            ViewBag.Course = db.Courses;
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
            ViewBag.Course = db.Courses.Where(x => x.id_subcat == id);
            return PartialView();
        }

        public ActionResult General()
        {
            ViewBag.Course = db.Courses;
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
    }
}