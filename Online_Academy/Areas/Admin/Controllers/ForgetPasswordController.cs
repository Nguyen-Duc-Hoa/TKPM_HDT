using Online_Academy.Areas.Admin.Service;
using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class ForgetPasswordController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Admin/ForgetPassword
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(string email)
        {
            var obj = db.Users.Where(u => u.email == email).FirstOrDefault();
            if(obj != null)
            {
                SendMail send = new SendMail();
                string randCode = send.sendMail(email);
                TempData["randCode"] = randCode;
                TempData["email"] = email;
                return View("VerificationCode");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ChangePassword(string code)
        {
            if(code == TempData["randCode"].ToString())
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
            string email = TempData["email"].ToString();
            var obj = db.Users.Where(u => u.email == email).FirstOrDefault();
            if(obj != null)
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
    }
}