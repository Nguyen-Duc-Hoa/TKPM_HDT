using System;
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
    public class TeachersController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        // GET: Teacher/Teachers
        public ActionResult Index()
        {
            TeachersClient tc = new TeachersClient();
            view_Teachers teacher = new view_Teachers();
            teacher = tc.find(2);
            return View(teacher);
        }

        
        [HttpPost]
        
        public ActionResult Edit( view_Teachers view_Teachers,HttpPostedFileBase file)
        {
            TeacherViewModel tv = new TeacherViewModel();
            UserViewModel uv = new UserViewModel();
            view_Teachers viewteacher = new view_Teachers();
           
            TeachersClient tc = new TeachersClient();
            //viewteacher = tc.findview_teacher(2);
          //  tv.teacher = tc.find(2);
            UsersClient uc = new UsersClient();
           
         
            //tv.teacher.description = view_Teachers.description;
            
           // tc.Edit(tv.teacher);
            uv.user = uc.find(2);
           
            if (file != null)
            {
                string ImageName = Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Assets/Pictures/ImagesUser/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);
                uv.user.avatar = ImageName;
            }
           
            
            uv.user.name = view_Teachers.name;
            uv.user.email = view_Teachers.email;
            uv.user.major = view_Teachers.major;
            uv.user.birthday = view_Teachers.birthday;
            uv.user.gender = view_Teachers.gender;
            uc.Edit(uv.user);
              return RedirectToAction("Index");
            
            
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
