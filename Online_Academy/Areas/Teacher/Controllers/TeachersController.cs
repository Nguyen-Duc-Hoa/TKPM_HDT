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
            int id = Convert.ToInt32(Session["userID"]);
            TeachersClient tc = new TeachersClient();
            view_Teachers teacher = new view_Teachers();
            teacher = tc.find(id);
            return View(teacher);
        }

        
        [HttpPost]
        
        public ActionResult Edit( view_Teachers view_Teachers,HttpPostedFileBase file)
        {
            int id = Convert.ToInt32(Session["userID"]);
            TeacherViewModel tv = new TeacherViewModel();
            UserViewModel uv = new UserViewModel();
           
            view_Teachers viewteacher = new view_Teachers();
           
            TeachersClient tc = new TeachersClient();
            //viewteacher = tc.findview_teacher(2);
          //  tv.teacher = tc.find(2);
            UsersClient uc = new UsersClient();


            //tv.teacher.description = view_Teachers.description;

            // tc.Edit(tv.teacher);
            uv.user = db.Users.Find(id);
           
            if (file != null)
            {
                string ImageName = Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Assets/Pictures/ImagesUser/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);
                uv.user.avatar = ImageName;
            }
           
            
            uv.user.name = view_Teachers.name.Trim();
            uv.user.email = view_Teachers.email.Trim();
            uv.user.major = view_Teachers.major.Trim();
            uv.user.birthday = view_Teachers.birthday;
            uv.user.gender = view_Teachers.gender.Trim();
            db.Entry(uv.user).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch(Exception e)
            {
               
            }
            return Redirect(Request.UrlReferrer.ToString());
            
            
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
