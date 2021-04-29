﻿using Online_Academy.Models;
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
        // GET: Account
        public ActionResult Index()
        {
            return View();
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
                if (dbUser.Role1.role1 == "Admin")
                {
                    return Content("Admin");
                }
                else if (dbUser.Role1.role1 == "Student")
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
                return Content("main page");
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
                role = 3
            };

            UsersClient usersClient = new UsersClient();
            if (usersClient.Create(user))
            {
                return Content("Success");
            }
            else
            {
                return Content("Fail");
            }
        }
        public ActionResult RegisterTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterTeacher(string name, string email, string username, string password)
        {
            User user = new User()
            {
                name = name,
                email = email,
                username = username,
                password = password,
                role = 2
            };

            UsersClient usersClient = new UsersClient();
            if (usersClient.Create(user))
            {
                return Content("Success");
            }
            else
            {
                return Content("Fail");
            }
        }
    }
}