using Online_Academy.Models;
using Online_Academy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Controllers
{
    public class AccountController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // Login view
        public ActionResult Login()
        {
            if (Request.Cookies["userName"] != null && Request.Cookies["pass"] != null)
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
            User dbUser = db.Users.Where(u => u.username == username && u.password == password && u.state == true).FirstOrDefault();
            if (dbUser != null)
            {
                if (rememberCheck == "true")
                {
                    Request.Cookies["userName"].Value = dbUser.username.Trim();
                    Request.Cookies["pass"].Value = dbUser.password.Trim();
                }

                Session["userID"] = dbUser.id.ToString().Trim();
                Session["UserId"] = dbUser.id.ToString().Trim();
                Session["userName"] = dbUser.username.ToString().Trim();
                Session["username"] = dbUser.username.ToString().Trim();
                Session["role"] = dbUser.Role1.role1.ToString().Trim();
                Session["avatar"] = dbUser.avatar.ToString().Trim();

                if (dbUser.avatar != null)
                {
                    Session["avatar"] = dbUser.avatar.ToString().Trim();
                }
                else
                {
                    // default avatar
                }

                // Move to main page base on Role
                if (dbUser.Role1.role1.Trim() == "Admin")
                {
                    return Content("/Admin/Home");
                }
                else if (dbUser.Role1.role1.Trim() == "Student")
                {
                    return Content("/Student/MainPage");
                }
                else
                {
                    return Content("/Teacher/Home");
                }
            }
            return Content("Fail");
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(string email)
        {
            var obj = db.Users.Where(u => u.email == email).FirstOrDefault();
            if (obj != null)
            {
                SendMail send = new SendMail();
                string randCode = send.sendMail(email);
                Session["randCode"] = randCode;
                Session["email"] = email;
                return View("VerificationCode");
            }
            return RedirectToAction("ForgetPassword");
        }
        [HttpPost]
        public ActionResult ChangePassword(string code)
        {
            if (code == Session["randCode"].ToString())
            {
                return View();
            }
            else
            {
                Response.Write("<script>alert('Mã xác nhận không chính xác')</script>");
                return View("VerificationCode");
            }
        }
        [HttpPost]
        public ActionResult changePasswordHandler(string confirmPass)
        {
            string email = Session["email"].ToString();
            var obj = db.Users.Where(u => u.email == email).FirstOrDefault();
            if (obj != null)
            {
                try
                {
                    obj.password = confirmPass;
                    UsersClient usersClient = new UsersClient();
                    usersClient.Edit(obj);
                }
                catch
                {
                    Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
                    return View("ChangePassword");
                }

                // Move to mainpage base on role
                return Content("mainpage");
            }
            Response.Write("<script>alert('Đã có lỗi xảy ra')</script>");
            return View("ChangePassword");
        }
        public ActionResult RegisterStudent()
        {
            return View();            
        }
        [HttpPost]
        public ActionResult RegisterStudent(string name, string email, string username, string password)
        {
            User user = new User()
            {
                name = name,
                email = email,
                username = username,
                password = password,
                avatar = "/UploadFiles/avatar-default.jpg",
                role = 3
            };

            //Use API
            //UsersClient usersClient = new UsersClient();
            //if (usersClient.Create(user))
            //{
            //    return Content("Success");
            //}
            //else
            //{
            //    return Content("Fail");
            //}

            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            catch
            {
                return Content("Fail");
            }
        }
        public ActionResult RegisterTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterTeacher(string name, string email, string username, string password, string major)
        {
            User user = new User()
            {
                name = name,
                email = email,
                username = username,
                password = password,
                role = 2,
                state = false,
                avatar = "/UploadFiles/avatar-default.jpg",
                major = major
            };

            // Use API
            //UsersClient usersClient = new UsersClient();
            //if (usersClient.Create(user))
            //{
            //    return Content("Success");
            //}
            //else
            //{
            //    return Content("Fail");
            //}

            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            catch
            {
                return Content("Fail");
            }
        }
        public ActionResult Logout()
        {
            //string role = Session["role"].ToString();
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult ChangeProfile()
        {
            // Use API instead

            //Test without login
            int id = 2;

            //if(Session["userID"] == null)
            //{
            //    return RedirectToAction("Login");
            //}
            //int id = Convert.ToInt32(Session["userID"].ToString());
            var dbuser = db.Users.Where(u => u.id == id).FirstOrDefault();

            // Show view base on role
            switch (dbuser.Role1.role1.Trim())
            {
                case "Student":
                    return View("ChangeProfileStudent", dbuser);
                case "Teacher":
                    return View("ChangeProfileTeacher", dbuser);
                default:
                    return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult ChangeProfileStudent(User user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var dbuser = db.Users.Where(u => u.id == user.id).FirstOrDefault();
                    dbuser.name = user.name;
                    dbuser.email = user.email;
                    dbuser.gender = user.gender;
                    dbuser.birthday = user.birthday;
                    if(TempData["avatar"] != null)
                    {
                        dbuser.avatar = TempData["avatar"].ToString();
                    }
                    
                    Session["avatar"] = dbuser.avatar;
                    db.SaveChanges();

                    return RedirectToAction("ChangeProfile");
                }
                else
                {
                    return RedirectToAction("ChangeProfile");
                }
            }
            catch
            {
                return RedirectToAction("ChangeProfile");
            }
        }
        [HttpPost]
        public ActionResult ChangeProfileTeacher(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dbuser = db.Users.Where(u => u.id == user.id).FirstOrDefault();
                    dbuser.name = user.name;
                    dbuser.email = user.email;
                    dbuser.gender = user.gender;
                    dbuser.birthday = user.birthday;
                    if(TempData["avatar"] != null)
                    {
                        dbuser.avatar = TempData["avatar"].ToString();
                    }
                    dbuser.Teacher.description = user.Teacher.description.Trim();
                    dbuser.major = user.major;
                    Session["avatar"] = dbuser.avatar;
                    db.SaveChanges();
                    return RedirectToAction("ChangeProfile");
                }
                else
                {
                    return RedirectToAction("ChangeProfile");
                }
            }
            catch
            {
                return RedirectToAction("ChangeProfile");
            }
        }
        public string Upload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/UploadFiles/" + file.FileName));
            TempData["avatar"] = "/UploadFiles/" + file.FileName;
            return "/UploadFiles/" + file.FileName;
        }
    }
}