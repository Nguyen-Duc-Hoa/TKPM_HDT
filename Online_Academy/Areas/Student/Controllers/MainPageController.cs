﻿using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Academy.Models;

namespace Online_Academy.Areas.Student.Controllers
{
    public class MainPageController : Controller
    {
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        // GET: Student/MainPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadCourse()
        {

            ViewBag.Course = db.Courses;
            return PartialView();
        }
        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult SubLayout()
        {
            return View();
        }

    }
}