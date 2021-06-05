using Facebook;
using Online_Academy.Models;
using Online_Academy.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Controllers
{
    public class AccountController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                //uriBuilder.Path = "/Account/FacebookCallback";
                uriBuilder.Path = "/Account/FacebookCallback";
                return uriBuilder.Uri;
            }
        }
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
                    Response.Cookies["userName"].Value = dbUser.username.Trim();
                    Response.Cookies["pass"].Value = dbUser.password.Trim();
                }
                else
                {
                    Response.Cookies["userName"].Value = null;
                    Response.Cookies["pass"].Value = null;
                }

                Session["userID"] = dbUser.id.ToString().Trim();
                Session["UserId"] = dbUser.id.ToString().Trim();
                Session["userName"] = dbUser.username.ToString().Trim();
                Session["username"] = dbUser.username.ToString().Trim();
                Session["role"] = dbUser.Role1.role1.ToString().Trim();
                Session["avatar"] = dbUser.avatar.ToString().Trim();

                

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

                    // Move to home page
                    if (obj.Role1.role1.Trim() == "Student")
                    {
                        return Content("/Student/MainPage");
                    }
                    else
                    {
                        return Content("/Teacher/Home");
                    }
                }
                catch
                {
                    return View("Error");
                }
            }
            return View("Error");
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
                state = true,
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
                var dbUser = db.Users.Where(u => (u.email.Trim() == user.email) || (u.username.Trim() == user.username)).ToList();
                if (dbUser.Count != 0)
                {
                    return Content("NotValid");
                }
                else
                {
                    TempData["user"] = user;
                    SendMailToVerify(user);
                    return Content("Valid");
                }
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
                state = true,
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
                var dbUser = db.Users.Where(u => (u.email.Trim() == user.email) || (u.username.Trim() == user.username)).ToList();
                if(dbUser.Count !=0 )
                {
                    return Content("NotValid");
                }
                else
                {
                    TempData["user"] = user;
                    SendMailToVerify(user);
                    return Content("Valid");
                }
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
            return Redirect("/Account/Login");
        }
        [HttpGet]
        public ActionResult ChangeProfile()
        {
            // Use API instead

            //Test without login
            //int id = 2;

            if (Session["userID"] == null)
            {
                return RedirectToAction("Login");
            }
            int id = Convert.ToInt32(Session["userID"].ToString());

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
        public void SendMailToVerify(User user)
        {
            //email của dự án
            string email = "nhomltweb@gmail.com";
            string password = "123456789a@";

            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 25);

            var baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/Account/ConfirmEmail?Email=" + user.email;

            msg.From = new MailAddress(email);
            msg.To.Add(user.email);
            msg.Subject = "Email confirmation";
            msg.Body = String.Format("Dear {0} <br/>Thank you for your registration, " +
                "please on the below link to complete your registration:<br/> " +
                "<a href=\"{1}\" title=\"User email confirm\">{1}</a>", 
                user.username, baseUrl);
            msg.IsBodyHtml = true;

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);
        }
        public ActionResult ConfirmEmail(string Email)
        {
            User user = TempData["user"] as User;
            if(user.email == Email)
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    User dbUser = assignSessionUser(Email);

                    if (dbUser.Role1.role1.Trim() == "Student")
                    {
                        return Redirect("/Student/MainPage");
                    }
                    else //Teacher
                    {
                        return Redirect("/Teacher/Home");
                    }
                }
                catch
                {
                    return View("Error");
                }
            }
            return View("Error");
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name, middle_name, last_name, id, email");
                string email = me.email;
                string name = me.first_name + me.middle_name + me.last_name;

                var lstUser = db.Users.Where(u => u.email.Trim() == email).ToList();
                if (lstUser.Count == 0)
                {
                    User user = new User()
                    {
                        name = name,
                        email = email,
                        username = name,
                        avatar = "/UploadFiles/avatar-default.jpg",
                        state = true,
                        role = 3
                    };
                    
                    try
                    {
                        db.Users.Add(user);
                        db.SaveChanges();

                        User dbUser = assignSessionUser(user.email);

                        if(dbUser.Role1.role1.Trim() == "Student")
                        {
                            return Redirect("/Student/MainPage");
                        }
                        else
                        {
                            return View("Error");
                        }
                    }
                    catch
                    {
                        return View("Error");
                    }
                }
                else if (lstUser.Count == 1)
                {
                    User dbUser = db.Users.Where(u => u.email.Trim() == email && u.password == null).FirstOrDefault();
                    if(dbUser != null)
                    {
                        Session["userID"] = dbUser.id.ToString().Trim();
                        Session["UserId"] = dbUser.id.ToString().Trim();
                        Session["userName"] = dbUser.username.ToString().Trim();
                        Session["username"] = dbUser.username.ToString().Trim();
                        Session["role"] = dbUser.Role1.role1.ToString().Trim();
                        Session["avatar"] = dbUser.avatar.ToString().Trim();

                        return Redirect("/Student/MainPage");
                    }
                }

            }
            else
            {
                ViewBag.message = "Email của facebook đã được sử dụng";
                return View("Error");
            }

            ViewBag.message = "Email của facebook đã được sử dụng";
            return View("Error");
        }
        public User assignSessionUser(string email)
        {
            User dbUser = db.Users.Include("Role1").Where(u => u.email.Trim() == email).FirstOrDefault();
            Session["userID"] = dbUser.id.ToString().Trim();
            Session["UserId"] = dbUser.id.ToString().Trim();
            Session["userName"] = dbUser.username.ToString().Trim();
            Session["username"] = dbUser.username.ToString().Trim();
            Session["role"] = dbUser.Role1.role1.ToString().Trim();
            Session["avatar"] = dbUser.avatar.ToString().Trim();

            return dbUser;
        }
    }
    
}