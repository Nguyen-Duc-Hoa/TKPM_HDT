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
            CourseClient CC = new CourseClient();
            ViewBag.Course = CC.GetCourseByUser(0).Where(x => x.id == id).FirstOrDefault();

            //Tinh count
            CurriculumClient CrC = new CurriculumClient();
            ViewBag.Curriculum = CrC.GetCurriculumByCourse(id);


            int idTecher = Convert.ToInt32(CC.GetCourse(id).id_teacher);
            if (Session["UserId"] != null)
            {
                try
                {
                    //kiem tra mon hoc co duoc like chua
                    int idUser = Convert.ToInt32(Session["UserId"]);
                    var course = CC.GetCourseByUser(idUser).Where(x => x.id == id).FirstOrDefault();
                    if(course != null)
                    {
                        ViewBag.Course = course;
                    }
                    //Kiem tra 1- da mua
                    ViewBag.test = db.Histories.Where(x => x.id_user == idUser && x.id_course == id).FirstOrDefault();
                    //Neeu nhu da mua
                    if( ViewBag.test != null)
                    {
                        GetTeacher(idTecher);

                        //load process
                        var process = db.Processes.Where(x => x.id_student == idUser && x.id_Course == id).FirstOrDefault();
                        int total = Convert.ToInt32(db.sp_SumLesson(id).Select(x => x.Value).FirstOrDefault());
                        //ViewBag.percent = 1 / total;
                        int percent = 1 / 2 * 100;
                        ViewBag.percent = percent;
                        ViewBag.process = process;
                        return View("CourseDetail1");
                    }
                }
                catch {
                    //Lay trong tin mon hoc
                    var course = CC.GetCourseByUser(0).Where(x => x.id == id).FirstOrDefault();
                    if (course != null)
                    {
                        ViewBag.Course = course;
                    }
                }

            }

            //Load thong tin teacher
            GetTeacher(idTecher);
            return View();
        }   

        //Lay thong tin cua giao vien cho trang chi tiet Course
        public void GetTeacher(int id)
        {
            TeachersClient TC = new TeachersClient();
            ViewBag.Teacher = TC.find(id);
        }

        //Load tat car cac chuong hoc khi vao chi tiet mon hoc
        public ActionResult LoadCurriculum(int idCourse)
        {
            CurriculumClient CC = new CurriculumClient();
            ViewBag.Curriculum = CC.GetCurriculumByCourse(idCourse);
            return PartialView();
        }

        //Load Lecture cho tung Curriculum
        public ActionResult LoadLecture(int idChapter)
        {
            LectureClient LC = new LectureClient();
            ViewBag.Lecture = LC.GetLecturesByChap(idChapter);
            return PartialView();
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

        public bool RemoveLike (int idCourse)
        {
            try
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                if(idUser != 0)
                {
                    //CourseClient CC = new CourseClient();
                    //CC.RemoveLike(idUser, idCourse);

                    db.sp_remove_favorite(idUser, idCourse);
                }
            }
            catch
            {
                return false;   
            }
            return true;
        }

        //click stype of course in nabar
        [HttpGet]
        public ActionResult CoursesByType(int id)
        {
            try
            {
                int iduser = Convert.ToInt32(Session["UserId"]);
                if (iduser != 0)
                {
                    CourseClient CC = new CourseClient();
                    var allCourse = CC.GetCourseByUser(iduser);
                    ViewBag.Course = allCourse.Where(x => x.id_subcat == id);
                    ViewBag.name = db.Subcategories.Where(x => x.id == id).Select(x=> x.subname).FirstOrDefault();
                    return View();
                }
            }
            catch {
                return View();
            }

            return View();

        }
    }
}