using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Student.Controllers
{
    public class MainPageController : Controller
    {
        // GET: Student/MainPage
        public ActionResult Index()
        {
            return View();
        }
    }
}