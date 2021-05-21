using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Academy.Models;

namespace Online_Academy.Areas.Student.Controllers
{
    public class LectureController : Controller
    {
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Student/Lecture
        public ActionResult Index()
        {
            return View();
        }
    }
}