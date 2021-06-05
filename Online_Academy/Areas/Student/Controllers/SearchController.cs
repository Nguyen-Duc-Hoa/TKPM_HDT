using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Student.Controllers
{
    public class SearchController : Controller
    {
        // GET: Student/Search
        public ActionResult Index(string text)
        {
            if(text == null)
            {
                if (Request["Text"] != null)
                {
                    text = Request["Text"];
                }
            }
            
            SearchClient SC = new SearchClient();
            ViewBag.course = SC.SearchbyName(text);
            ViewBag.text = text;
            return View();
        }




    }
}