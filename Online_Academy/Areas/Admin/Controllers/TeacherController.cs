using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Admin/Teacher
        public ActionResult Index()
        {
            // get teachers, whose state is false (NOT USE API)
            List<User> listTeacher = db.Users.Where(t => t.Role1.role1 == "Teacher" && t.state == false).ToList();

            ViewBag.lstTeacher = listTeacher;

            return View();
        }
        [HttpPost]
        // accept account of teacher => teacher can upload course
        public ActionResult Approve(int idTeacher)
        {
            try
            {
                var dbTeacher = db.Users.Where(t => t.id == idTeacher).FirstOrDefault();
                dbTeacher.state = true;
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Fail");
            }
        }
        [HttpPost]
        // reject account of teacher => remove account from database
        public ActionResult Cancel(int idTeacher)
        {
            try
            {
                var dbTeacher = db.Users.Where(t => t.id == idTeacher).FirstOrDefault();
                db.Users.Remove(dbTeacher);
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return Content("Fail");
            }
        }
    }
}