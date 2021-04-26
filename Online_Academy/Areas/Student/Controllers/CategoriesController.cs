using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Academy.Models;

namespace Online_Academy.Areas.Student.Controllers
{
    public class CategoriesController : Controller
    {
        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        CategoriesClient CC = new CategoriesClient();

        // GET: Student/Categories
        public ActionResult Index()
        {
            ViewBag.cate = CC.findAll();
            LoadSubcate();

            return PartialView();
        }

        public ActionResult LoadSubcate()
        {
            ViewBag.Subcate = db.Subcategories;
            return PartialView();
        }
    }
}