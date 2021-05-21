﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Academy.Models;
using Online_Academy.ViewModel;

namespace Online_Academy.Areas.Teacher.Controllers
{
    public class TeacherCoursesController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: Teacher/Courses

        public ActionResult Index()
        {
           List< CourseViewModel> cvm = new List<CourseViewModel>();
            CourseClient cc = new CourseClient();
            TeachersClient tc = new TeachersClient();
            foreach (var course in cc.GetCoursesByState(true))
            {
                CourseViewModel c = new CourseViewModel();
                c.course = course;
                c.teacher = tc.findview_teacher(course.id_teacher);
                cvm.Add(c);
            }
            ViewBag.listCourses = cvm;
            return View();
        }
        public ActionResult Draft()
        {
            List<CourseViewModel> cvm = new List<CourseViewModel>();
            CourseClient cc = new CourseClient();
            TeachersClient tc = new TeachersClient();
            foreach (var course in cc.GetCoursesByState(false))
            {
                CourseViewModel c = new CourseViewModel();
                c.course = course;
                c.teacher = tc.findview_teacher(course.id_teacher);
                cvm.Add(c);
            }
            ViewBag.listCourses = cvm;
            return View();
        }
        public ActionResult Students(int id)
        {
            UsersClient uc = new UsersClient();
            UserViewModel user = new UserViewModel();
           List< UserViewModel> usermodel = new List<UserViewModel>();
            List<int?> listid = db.getStudentByCourse(id).ToList();

            for(int i=0;i<listid.Count;i++)
            {
                user.user = uc.find((int)listid[i]);
                usermodel.Add(user);
            }
            ViewBag.liststudents = usermodel;
            return View("Students");
        }
        public ActionResult ProfileUser(int id)
        {
            UsersClient uc = new UsersClient();
            UserViewModel user = new UserViewModel();
            user.user = uc.find(id);
           
            ViewBag.user = user.user;
            return View("Profile");
        }
        // GET: Teacher/Courses/Details/5
        public ActionResult Details(int id)
        {

            CourseViewModel cvm = new CourseViewModel();
            CourseClient cc = new CourseClient();
            LectureClient lec = new LectureClient();
            SubcategoriesClient sub = new SubcategoriesClient();
            int? count=0 ;
            int? numberstudents = 0;
            CurriculumClient curri = new CurriculumClient();
            TeachersClient tc = new TeachersClient();
            Course course = cc.GetCourse(id);
            List<Curriculum> curriculum = curri.GetCurriculumByCourse(id);
            List<List<Lecture>> lecture = new List<List<Lecture>>();
            for(int i=0;i<curriculum.Count;i++)
            {
                var a = db.getNumberofLectures(curriculum[i].id).FirstOrDefault();
               
                    count += a;
                lecture.Add(lec.GetLectureByCurriculum(curriculum[i].id));
                
            }
            Subcategory subcat = sub.find(course.id_subcat);

            numberstudents = db.getNumberofStudents(id).FirstOrDefault();
                cvm.course = course;
                cvm.teacher = tc.findview_teacher(course.id_teacher);
                
            
            ViewBag.numberlectures = count;
            ViewBag.subcat = subcat.subname;
            ViewBag.numberstudents = numberstudents;
            ViewBag.listcurri = curriculum;
            ViewBag.listlectures = lecture;
            return View(cvm);
        }

        // GET: Teacher/Courses/Create
        public ActionResult Create()
        {
            
            ViewBag.id_subcat = new SelectList(db.Subcategories, "id", "subname");
           
            return View();
        }

        // POST: Teacher/Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public void Create(FormCollection formdata)
        {
            Course course = new Course();
       
            // lecture.chapname = ;
            List<string> s = Request.Form["chaptername"].Split(',').ToList();

            //lecture.chapname = s;
            HttpPostedFileBase img = Request.Files["fileimg"];
            HttpPostedFileBase preview = Request.Files["preview"];
            if (img != null)
            {
                string ImageName = Path.GetFileName(img.FileName);
                string physicalPath = Server.MapPath("~/Assets/Pictures/ImagesCourse/" + ImageName);

                // save image in folder
                img.SaveAs(physicalPath);
                course.thumbnail = ImageName;
            }
            if (preview != null)
            {
                string VideoName = Path.GetFileName(preview.FileName);
                string physicalPath = Server.MapPath("~/Assets/Videos/" + VideoName);

                // save image in folder
                preview.SaveAs(physicalPath);
                course.preview = VideoName;
            }
            course.name = formdata["namecourse"];
            course.description = formdata["description"];
            course.short_description = formdata["shortdes"];
            course.id_subcat=Convert.ToInt32(formdata["sub"]);
            course.price=Convert.ToInt32( formdata["price"]);
            course.discount = Convert.ToInt32(formdata["discount"]);
            course.id_teacher = 2;
            if(Convert.ToInt32(formdata["state"])==0)
                course.state = false;
            else
                course.state = true;
            db.Courses.Add(course);
            db.SaveChanges();
            int id_course = course.id;
          
            List<Curriculum> curriculums = new List<Curriculum>();
         
            for (int i = 0; i < s.Count; i++)
            {
                Curriculum curri = new Curriculum();
                curri.chap_name = s[i];
                curri.id_course = id_course;
                db.Curricula.Add(curri);
                db.SaveChanges();
                int id_curri = curri.id;
                int videocount =Convert.ToInt32(Request.Form["lengthvideo["+i+"]"]);
                for (int j = 0; j < videocount; j++)
                {
                    Lecture lec = new Lecture();
                    HttpPostedFileBase video = Request.Files["linkvideo[" + i + "]" + "[" + j + "]"];
                    if (video != null)
                    {
                        string VideoName = Path.GetFileName(video.FileName);
                        string physicalPath = Server.MapPath("~/Assets/VideosLecture/" + VideoName);

                        // save image in folder
                        video.SaveAs(physicalPath);
                        lec.link = VideoName;
                    }

                    
                  
                    lec.name = Request.Form["videoname[" + i + "]" + "[" + j + "]"];

                    lec.id_chapter = id_curri;
                    db.Lectures.Add(lec);
                    db.SaveChanges();
                }
            }




            //ViewBag.id_subcat = new SelectList(db.Subcategories, "id", "subname", course.id_subcat);
            //ViewBag.id_teacher = new SelectList(db.Teachers, "id", "description", course.id_teacher);

            //return RedirectToAction("Index");
           
        }

        // GET: Teacher/Courses/Edit/5
        public ActionResult Edit(int id)
        {
           
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            LectureClient lecture = new LectureClient();
            CurriculumClient curriculum = new CurriculumClient();
            List<Curriculum> curri = new List<Curriculum>();
            curri= curriculum.GetCurriculumByCourse(id);
            ViewBag.curricula = curri;
            List<List<Lecture>> lec = new List<List<Lecture>>();
            for(int i=0;i<curri.Count;i++)
            {
                
                lec.Add(lecture.GetLectureByCurriculum(curri[i].id));
            }
            ViewBag.lectures = lec;
            ViewBag.id_subcat = new SelectList(db.Subcategories, "id", "subname", course.id_subcat);
          //  ViewBag.id_teacher = new SelectList(db.Teachers, "id", "description", course.id_teacher);
            return View(course);
        }

        // POST: Teacher/Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
   
        public ActionResult Edit(FormCollection formdata)
        {

            Course course = new Course();
           
            CourseClient cc = new CourseClient();
            CurriculumClient curriclient = new CurriculumClient();
            LectureClient lc = new LectureClient();
            // lecture.chapname = ;
            List<string> s = Request.Form["chaptername"].Split(',').ToList();
            List<string> idcurri =Request.Form["idcurri"].Split(',').ToList();
            course.id = Convert.ToInt32(formdata["idcourse"]);
            //lecture.chapname = s;
            HttpPostedFileBase img = Request.Files["fileimg"];
            HttpPostedFileBase preview = Request.Files["preview"];
            if (img != null)
            {
                string ImageName = Path.GetFileName(img.FileName);
                string physicalPath = Server.MapPath("~/Assets/Pictures/ImagesCourse/" + ImageName);

                // save image in folder
                img.SaveAs(physicalPath);
                course.thumbnail = ImageName;
            }
            else
            {

                course.thumbnail = cc.GetCourse(course.id).thumbnail;
                
            }
            if (preview != null)
            {
                string VideoName = Path.GetFileName(preview.FileName);
                string physicalPath = Server.MapPath("~/Assets/Videos/" + VideoName);

                // save image in folder
                preview.SaveAs(physicalPath);
                course.preview = VideoName;
            }
            else
            {

                course.preview = cc.GetCourse(course.id).preview;

            }

            course.name = formdata["namecourse"];
            course.description = formdata["description"];
            course.short_description = formdata["shortdes"];
            course.id_subcat = Convert.ToInt32(formdata["sub"]);
            course.price = Convert.ToInt32(formdata["price"]);
            course.discount = Convert.ToInt32(formdata["discount"]);
            course.id_teacher = 2;
            if (Convert.ToInt32(formdata["state"]) == 0)
                course.state = false;
            else
                course.state = true;
            cc.UpdateCourse(course);
            int id_course = course.id;

            List<Curriculum> curriculums = new List<Curriculum>();
            for (int i = 0; i < s.Count; i++)
            {
                Curriculum curri = new Curriculum();
                curri.chap_name = s[i];
                curri.id_course = id_course;
                if (idcurri[i]!="")
                {
                    
                    curri.id = Convert.ToInt32(idcurri[i]);
                    curriclient.UpdateCurriculum(curri);
                }
                else
                {
                    
                    db.Curricula.Add(curri);
                    db.SaveChanges();
                }
                int id_curri = curri.id;
                int videocount = Convert.ToInt32(Request.Form["lengthvideo[" + i + "]"]);
                for (int j = 0; j < videocount; j++)
                {

                    Lecture lec = new Lecture();
                    lec.name = Request.Form["videoname[" + i + "]" + "[" + j + "]"];
                    lec.id_chapter = id_curri;
                    HttpPostedFileBase video = Request.Files["linkvideo[" + i + "]" + "[" + j + "]"];
                    if (Request.Form["idlec[" + i + "]" + "[" + j + "]"] != "")
                    {
                        lec.id = Convert.ToInt32(Request.Form["idlec[" + i + "]" + "[" + j + "]"]);

                        if (video != null)
                        {
                            string VideoName = Path.GetFileName(video.FileName);
                            string physicalPath = Server.MapPath("~/Assets/VideosLecture/" + VideoName);

                            // save image in folder
                            video.SaveAs(physicalPath);
                            lec.link = VideoName;
                        }
                        else
                        {
                            lec.link = lc.GetLecture(lec.id).link;
                        }
                        lc.UpdateLecture(lec);
                    }
                    
            
                    else
                    {
                        if (video != null)
                        {
                            string VideoName = Path.GetFileName(video.FileName);
                            string physicalPath = Server.MapPath("~/Assets/VideosLecture/" + VideoName);

                            // save image in folder
                            video.SaveAs(physicalPath);
                            lec.link = VideoName;
                        }
                        db.Lectures.Add(lec);
                        db.SaveChanges();
                    }
                    
                    
                   
                }
            }
            
            return RedirectToAction("Index");
            
           
        }

        // GET: Teacher/Courses/Delete/5
        public ActionResult Delete(int id)
        {
            CourseClient cc = new CourseClient();
            CurriculumClient curriclient = new CurriculumClient();
            LectureClient lecclient = new LectureClient();
           
            List<Curriculum> curri = new List<Curriculum>();
            curri = curriclient.GetCurriculumByCourse(id);
         
            List<List<Lecture>> listlec = new List<List<Lecture>>();
            for (int i = 0; i < curri.Count; i++)
            {

                listlec.Add(lecclient.GetLectureByCurriculum(curri[i].id));
            }
            for(int j=0;j<listlec.Count;j++)
            {
                for(int k=0;k<listlec[j].Count;k++)
                {
                    lecclient.DeleteLecture(listlec[j][k].id);
                }
            }
            for(int m=0;m<curri.Count;m++)
            {
                curriclient.DeleteCurriculum(curri[m].id);
            }
            cc.DeleteCourse(id);
            List<CourseViewModel> cvm = new List<CourseViewModel>();
            CourseClient course = new CourseClient();
            TeachersClient tc = new TeachersClient();
            foreach (var item in course.GetCoursesByState(true))
            {
                CourseViewModel c = new CourseViewModel();
                c.course = item;
                c.teacher = tc.findview_teacher(item.id_teacher);
                cvm.Add(c);
            }
            ViewBag.listCourses = cvm;
            return PartialView("~/Areas/Teacher/Views/TeacherCourses/TeacherCourses.cshtml");
        }
        public ActionResult DeleteDraft(int id)
        {
            CourseClient cc = new CourseClient();
            CurriculumClient curriclient = new CurriculumClient();
            LectureClient lecclient = new LectureClient();

            List<Curriculum> curri = new List<Curriculum>();
            curri = curriclient.GetCurriculumByCourse(id);

            List<List<Lecture>> listlec = new List<List<Lecture>>();
            for (int i = 0; i < curri.Count; i++)
            {

                listlec.Add(lecclient.GetLectureByCurriculum(curri[i].id));
            }
            for (int j = 0; j < listlec.Count; j++)
            {
                for (int k = 0; k < listlec[j].Count; k++)
                {
                    lecclient.DeleteLecture(listlec[j][k].id);
                }
            }
            for (int m = 0; m < curri.Count; m++)
            {
                curriclient.DeleteCurriculum(curri[m].id);
            }
            cc.DeleteCourse(id);
            List<CourseViewModel> cvm = new List<CourseViewModel>();
            CourseClient course = new CourseClient();
            TeachersClient tc = new TeachersClient();
            foreach (var item in course.GetCoursesByState(false))
            {
                CourseViewModel c = new CourseViewModel();
                c.course = item;
                c.teacher = tc.findview_teacher(item.id_teacher);
                cvm.Add(c);
            }
            ViewBag.listCourses = cvm;
            return PartialView("~/Areas/Teacher/Views/TeacherCourses/TeacherCoursesDraft.cshtml");
        }
        public ActionResult DeleteCurriculum(int idcourse,int idcurri)
        {
           
           

            CurriculumClient curriculum = new CurriculumClient();
            LectureClient lecture = new LectureClient();
            
           
            List<Lecture> listlec = lecture.GetLectureByCurriculum(idcurri);
           
            for(int j=0;j<listlec.Count;j++)
            {
                lecture.DeleteLecture(listlec[j].id);
            }
            curriculum.DeleteCurriculum(idcurri);

            List<Curriculum> curri = new List<Curriculum>();
            curri = curriculum.GetCurriculumByCourse(idcourse);
            ViewBag.curricula = curri;
            List<List<Lecture>> lec = new List<List<Lecture>>();
            for (int i = 0; i < curri.Count; i++)
            {

                lec.Add(lecture.GetLectureByCurriculum(curri[i].id));
            }
            ViewBag.lectures = lec;

            return PartialView("~/Areas/Teacher/Views/TeacherCourses/Chapter.cshtml");
        }
        public ActionResult DeleteLecture(int idcourse, int idlec)
        {



            CurriculumClient curriculum = new CurriculumClient();
            LectureClient lecture = new LectureClient();


           Lecture lec = lecture.GetLecture(idlec);
            lecture.DeleteLecture(lec.id);
           
            List<Curriculum> curri = new List<Curriculum>();
            curri = curriculum.GetCurriculumByCourse(idcourse);
            ViewBag.curricula = curri;
            List<List<Lecture>> listlec = new List<List<Lecture>>();
            for (int i = 0; i < curri.Count; i++)
            {

                listlec.Add(lecture.GetLectureByCurriculum(curri[i].id));
            }
            ViewBag.lectures = listlec;

            return PartialView("~/Areas/Teacher/Views/TeacherCourses/Chapter.cshtml");
        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}