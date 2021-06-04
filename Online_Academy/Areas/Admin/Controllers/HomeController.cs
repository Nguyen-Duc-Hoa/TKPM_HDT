using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        public bool AuthorizeAdmin()
        {
            if (Session["role"] == null)
            {
                return false;
            }
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
        [HttpPost]
        public JsonResult NewChart()
        {
            List<object> iData = new List<object>();
            var courses = db.Courses.ToList();
            var histories = db.Histories.ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Courses", System.Type.GetType("System.String"));
            dt.Columns.Add("Students", System.Type.GetType("System.Int32"));

            foreach(var course in courses)
            {
                DataRow dr = dt.NewRow();
                dr["Courses"] = course.name.Trim();
                int totalStudent = 0;
                for(int i = 0; i < histories.Count; i++)
                {
                    if(histories[i].id_course == course.id)
                    {
                        totalStudent++;
                    }
                }
                dr["Students"] = totalStudent;
                dt.Rows.Add(dr);
            }

            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SecondChart()
        {
            List<object> iData = new List<object>();
            var courses = db.Courses.ToList();
            var histories = db.Histories.ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("Courses", System.Type.GetType("System.String"));
            dt.Columns.Add("TurnOver", System.Type.GetType("System.Int32"));

            foreach (var course in courses)
            {
                DataRow dr = dt.NewRow();
                dr["Courses"] = course.name.Trim();
                int totalStudent = 0;
                for (int i = 0; i < histories.Count; i++)
                {
                    if (histories[i].id_course == course.id)
                    {
                        totalStudent++;
                    }
                }
                int finalPrice = 0;
                if(course.discount == 0)
                {
                    finalPrice = (int)(course.price * totalStudent);
                }
                else
                {
                    finalPrice = (int)((course.price * (100 - course.discount) / 100) * totalStudent);
                }
                dr["TurnOver"] = finalPrice;
                dt.Rows.Add(dr);
            }

            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadTable()
        {
            List<object> tableData = new List<object>();
            var courses = db.Courses.ToList();
            var histories = db.Histories.ToList();
            foreach (var course in courses)
            {
                int totalStudent = 0;
                for (int i = 0; i < histories.Count; i++)
                {
                    if (histories[i].id_course == course.id)
                    {
                        totalStudent++;
                    }
                }
                var finalPrice = 0;
                if(course.discount == 0)
                {
                    finalPrice = (int)course.price * totalStudent;
                }
                else
                {
                    finalPrice = (int)(course.price * (100 - course.discount) / 100) * totalStudent;
                }
                var tData = new {courseName = course.name.Trim(), teacherName = course.Teacher.User.name, numStudent = totalStudent, price = course.price, discount = course.discount, turnOver = finalPrice };
                tableData.Add(tData);
            }
            return Json(tableData, JsonRequestBehavior.AllowGet);
        }
    }
}