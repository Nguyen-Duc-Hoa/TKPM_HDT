using Online_Academy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Student.Controllers
{
    public class ManageController : Controller
    {

        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();

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


        public ActionResult Profile()
        {
            if(AuthorizeUser())
            {
                int idStu = Convert.ToInt32(Session["UserId"]);
                UsersClient UC = new UsersClient();
                ViewBag.student = UC.find(idStu);
                return View();
            }
            return Redirect("/Account/Login");
        }


        //show danh sach cac mon hoc chua mua
        public ActionResult NotBought()
        {
            if(AuthorizeUser())
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                CourseClient CC = new CourseClient();
                ViewBag.notBought = CC.GetCourse_notBought(idUser);
                return View();
            }

            return Redirect("/Account/Login");

        }


        //Lay danh sach mon hoc da luu trong cart
        public ActionResult Cart()
        {
            if(AuthorizeUser())
            {
                int idUser = Convert.ToInt32(Session["UserId"]);
                CartClient CC = new CartClient();
                ViewBag.cart = CC.getCartbyUser(idUser);
                return View();
            }
            return Redirect("/Account/Login");
            
        }

        //Them khoa hoc vao cart
        public bool InsertCart(int idCourse)
        {
            if(AuthorizeUser())
            {
                try
                {
                    int idUser = Convert.ToInt32(Session["UserId"]);
                    Cart cart = new Cart();
                    cart.id_user = idUser;
                    cart.id_course = idCourse;
                    db.Carts.Add(cart);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    Response.Write(@"<script language='javascript'>alert('Message: \n" + "Something was wrong!" + " .');</script>");
                }
            }
            Redirect("/Account/Login");
            return false;
        }


        //Xoa khoa hoc khoi Cart
        public ActionResult RemoveCart(int id)
        {
            if(AuthorizeUser())
            {
                try
                {
                    int idUser = Convert.ToInt32(Session["UserId"]);
                    var CartItem = db.Carts.Where(x => x.id_course == id && x.id_user == idUser).FirstOrDefault();
                    if(CartItem != null)
                    {
                        db.Carts.Remove(CartItem);
                        db.SaveChanges();
                        return RedirectToAction("Cart");
                    }
                }
                catch
                {

                }
            }
            Response.Write(@"<script language='javascript'>alert('Message: \n" + "Something was wrong!" + " .');</script>");
            return RedirectToAction("Cart");        
        }

 
        [HttpPost]
        public ActionResult EditProfile()
        {
            if(AuthorizeUser())
            {
                try
                {
                    int id = Convert.ToInt32(Session["UserId"]);
                    string name = Request["Name"];
                    string gender = Request["Gender"];
                    DateTime date = Convert.ToDateTime(Request["Birthdate"]);

                    User user = db.Users.Where(x => x.id == id).FirstOrDefault();
                    if(user != null)
                    {
                        user.name = name.Trim();
                        user.birthday = date;
                        
                        if(gender != null)
                        {
                            user.gender = gender.Trim();
                        }
                        if(Session["newavatar"] != null)
                        {
                            user.avatar = Session["newavatar"].ToString().Trim();
                            Session["avatar"] = Session["newavatar"].ToString().Trim();
                        }

                        db.Entry(user).State = EntityState.Modified;

                        try
                        {
                            db.SaveChanges();
                            
                        }
                        catch (Exception e)
                        {
                            Response.Write(@"<script language='javascript'>alert('Message: \n" + "Something was wrong!" + " .');</script>");
                        }

                    }
                }
                catch { }
            }

            Response.Write(@"<script language='javascript'>alert('Message: \n" + "Successfully" + " .');</script>");
            return RedirectToAction("Profile");
        }


        public string Upload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/UploadFiles/" + file.FileName));
            Session["newavatar"] = "/UploadFiles/"+file.FileName;
            return "/UploadFiles/" + file.FileName;
        }


        
    }
}