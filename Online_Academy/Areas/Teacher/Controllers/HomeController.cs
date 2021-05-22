﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Teacher.Controllers
{
    public class HomeController : Controller
    {
        // GET: Teacher/Home
        public ActionResult Index()
        {
            int a = Convert.ToInt32(Session["userID"]);
            if ( a==0|| Session["userID"]==null|| Session["role"].ToString() != "Teacher")
            {
                return View("../Account/Login");
               
            }
            else
            {
                return View("Dashboard");
            }
            
        }
    }
}