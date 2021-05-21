﻿using Online_Academy.Helper;
using Online_Academy.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Academy.Areas.Student.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Student/Payment

        DB_A72902_TKPMEntities db = new DB_A72902_TKPMEntities();
        private PayPal.Api.Payment payment;
        private float tyGiaUSD = 22000;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHistory()
        {
            try
            {
                HistoriesClient HC = new HistoriesClient();
                var history = new History();
                history.id_course = Convert.ToInt32(Session["idCourse"].ToString());
                history.id_user = Convert.ToInt32(Session["UserId"].ToString());
                history.price = Convert.ToDouble(Session["price"].ToString());
                history.date = DateTime.Now;
                db.Histories.Add(history);
                db.SaveChanges();
                
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Student/Courses/CourseDetail/");
        }

        public ActionResult PaymentWithPaypal()
        {

            //getting the apiContext as earlier
            APIContext apiContext = Configuration.GetAPIContext();
            try
            {

                AddHistory();

                    string payerId = Request.Params["PayerID"];
                    if (string.IsNullOrEmpty(payerId))
                    {
                        //this section will be executed first because PayerID doesn't exist
                        //it is returned by the create function call of the payment class
                        // Creating a payment
                        // baseURL is the url on which paypal sendsback the data.
                        // So we have provided URL of this controller only
                        string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Paypal/PaymentWithPayPal?";
                        //guid we are generating for storing the paymentID received in session
                        //after calling the create function and it is used in the payment execution
                        var guid = Convert.ToString((new Random()).Next(100000));
                        //CreatePayment function gives us the payment approval url
                        //on which payer is redirected for paypal account payment
                        var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);

                        var links = createdPayment.links.GetEnumerator();
                        string paypalRedirectUrl = null;
                        while (links.MoveNext())
                        {
                            Links lnk = links.Current;
                            if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                            {
                                //saving the payapalredirect URL to which user will be redirected for payment
                                paypalRedirectUrl = lnk.href;
                            }
                        }
                        // saving the paymentID in the key guid
                        Session.Add(guid, createdPayment.id);
                        return Redirect(paypalRedirectUrl);
                    }
                    else
                    {
                        // This section is executed when we have received all the payments parameters
                        // from the previous call to the function Create
                        // Executing a payment
                        var guid = Request.Params["guid"];
                        var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                        if (executedPayment.state.ToLower() != "approved")
                        {
                            return View("FailureView");
                        }
                    }


            }
            catch (Exception ex)
            {
                Logger.Log("Error" + ex.Message);
                ViewBag.error = ex.Message.ToString();
                return View("FailureView");
            }
            return View("SuccessView");
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var itemList = new ItemList() { items = new List<Item>() };
            //Các giá trị bao gồm danh sách sản phẩm, thông tin đơn hàng
            //Sẽ được thay đổi bằng hành vi thao tác mua hàng trên website
            var n = Session["course"].ToString();
            itemList.items.Add(new Item()
            {
                //Thông tin đơn hàng
                name = Session["course"].ToString(),
                currency = "USD",
                price = Math.Round(Convert.ToDouble(Session["price"])/tyGiaUSD, 2).ToString(),
                quantity = "1",
                sku = "sku"
            });
            //Hình thức thanh toán qua paypal
            var payer = new Payer() { payment_method = "paypal" };
            // Configure Redirect Urls here with RedirectUrls object
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };
            //các thông tin trong đơn hàng
            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = "0"
            };
            //Đơn vị tiền tệ và tổng đơn hàng cần thanh toán
            var t = Math.Round(Convert.ToDouble(Session["price"]) / tyGiaUSD, 2).ToString(); // Total must be equal to sum of shipping, tax and subtotal.
            var amount = new Amount()
            {
                currency = "USD",
                
                total = Math.Round(Convert.ToDouble(Session["price"]) / tyGiaUSD, 2).ToString(), // Total must be equal to sum of shipping, tax and subtotal.
                details = details
            };
            var transactionList = new List<Transaction>();
            //Tất cả thông tin thanh toán cần đưa vào transaction
            transactionList.Add(new Transaction()
            {
                description = "Transaction description.",
                invoice_number = "your invoice number",
                amount = amount,
                item_list = itemList
            });

            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext
            return this.payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }
    }

}