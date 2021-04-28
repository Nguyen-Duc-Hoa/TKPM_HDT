using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Admin/Login
        // Load view Login page
        public ActionResult Index()
        {
            if(Request.Cookies["userName"] != null && Request.Cookies["pass"] != null)
            {
                ViewBag.userName = Request.Cookies["userName"].Value;
                ViewBag.pass = Request.Cookies["pass"].Value;
            }
            else
            {
                ViewBag.userName = "";
                ViewBag.pass = "";
            }
            return View();
        }
        [HttpPost]
        public ActionResult SubmitLogin(string username, string password, string rememberCheck)
        {
            User dbUser = db.Users.Where(u => u.username == username && u.password == password).FirstOrDefault();
            if (dbUser != null)
            {
                if (rememberCheck == "true")
                {
                    Request.Cookies["userName"].Value = dbUser.username;
                    Request.Cookies["pass"].Value = dbUser.password;
                }

                Session["userID"] = dbUser.id.ToString();
                Session["userName"] = dbUser.username.ToString();
                Session["role"] = dbUser.role.ToString();

                if (dbUser.avatar != null)
                {
                    Session["avatar"] = dbUser.avatar.ToString();
                }
                else
                {
                    // default avatar
                }

                // Move to main page base on Role
                if(dbUser.Role1.role1 == "Admin")
                {
                    return Content("Admin");
                }
                else if(dbUser.Role1.role1 == "Student")
                {
                    return Content("Student");
                }
                else
                {
                    return Content("Teacher");
                }
            }
            return Content("Fail");
        }
    }
}