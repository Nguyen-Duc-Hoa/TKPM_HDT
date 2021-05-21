using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public bool AuthorizeAdmin()
        {
            if (Session["role"].ToString() == "Admin")
            {
                return true;
            }
            return false;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (!AuthorizeAdmin())
            {
                return Redirect("Account/Login");
            }
            return View();
        }
    }
}