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
        public bool AuthorizeAdmin()
        {
            if (Session["role"].ToString() == "Admin")
            {
                return true;
            }
            return false;
        }
        // GET: Admin/Teacher
        public ActionResult Index()
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            // get teachers, whose state is false (NOT USE API)
            List<User> listTeacher = db.Users.Where(t => t.Role1.role1 == "Teacher").ToList();

            ViewBag.lstTeacher = listTeacher;

            return View();
        }
        [HttpPost]
        // accept account of teacher => teacher can upload course
        public ActionResult Approve(int idTeacher)
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
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
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            try
            {
                var dbTeacher = db.Users.Where(t => t.id == idTeacher).FirstOrDefault();
                dbTeacher.state = false;
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