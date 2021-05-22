using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Student.Controllers
{
    public class ManageController : Controller
    {
        // GET: Student/Manage
        public ActionResult Index()
        {
            return View();
        }

        public bool AuthorizeUser()
        {
            try
            {
                if(Convert.ToInt32(Session["UserId"]) == 0)
                {
                    return false;
                }   
            }
            catch
            {
                return false;
            }

            return true;
        }
        public ActionResult Purchase()
        {
            if(AuthorizeUser())
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                PurchaseClient PC = new PurchaseClient();
                ViewBag.purchase = PC.GetPurchase(idUser);

                return View();
            }
            return Redirect("/Account/Login");
        }
    }
}