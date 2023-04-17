using MinistryApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using MinistryApp.Utility;
using Microsoft.AspNetCore.Authorization;

namespace MinistryApp.Controllers
{
    public class MessageController : Controller
    {
        public IConfiguration _configuration;

        private readonly ILogger<MessageController> _logger;


        public MessageController(IConfiguration configuration, ILogger<MessageController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<SelectListItem> items = PopulateFlatOwners();
            return View(items);
        }


        [HttpPost]
        public ActionResult Index(string submit, string[] flatOwnerList, string txtMsgBody)
        {
            var APART_CODE_LOCAL_VAR = HttpContext.Request.Cookies["COMCODE"];
            var APART_APART_LOCAL_VAR = HttpContext.Request.Cookies["COMNAME"];

            String msgBody="";
            try
            {
                if(txtMsgBody != ""&& txtMsgBody != null)
                {
                    msgBody = txtMsgBody.ToString();
                }
                
            }catch(Exception ex)
            {

            }
            ViewBag.Message = "Message sent to:\\n";
            string msgStr = "";
            List<SelectListItem> items = PopulateFlatOwners();


            switch (submit)
            {
                case "Email":
                    //return (EmailInvitation());


                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("green.man6686@gmail.com");
                       
                        foreach (SelectListItem item in items)
                        {
                            if (flatOwnerList.Contains(item.Value))
                            {
                                item.Selected = true;
                                ViewBag.Message += string.Format("{0},{1}\\n", item.Text, item.Value);
                                mail.To.Add(item.Value);
                            }
                        }
                        msgStr += "Email Sent";
                        mail.Subject = "Invitation";
                        mail.Body = msgBody +"Thanks And Best Regards "+ APART_APART_LOCAL_VAR;
                        mail.IsBodyHtml = true;
                        //  mail.Attachments.Add(new Attachment("C:\\file.zip"));

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("elongatesdev@gmail.com", "aqitzohxddzutnve");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    return View(items);


                case "SMS":
                    //return (SMSInvitation());

                    foreach (SelectListItem item in items)
                    {
                        if (flatOwnerList.Contains(item.Value))
                        {
                            item.Selected = true;
                            
                            ViewBag.Message += string.Format("{0},{1}\\n", item.Text, item.Value);
                            BroadCast bObj = new BroadCast();
                            bObj.sendBroadCastSMS("SMS", GetMobileNumber(item.Value), msgBody);
                            //SendSMS("+18106921420", GetMobileNumber(item.Value), msgBody);
                        }
                    }
                    msgStr += "SMS Sent";
                    ViewBag.MessageMsg = msgStr;
                    return View(items);

            }
            return View();
        }

        //[HttpPost]
        //public ActionResult EmailInvitation()
        //{
        //    TempData["Message"] = "You clicked Email!";
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult SMSInvitation()
        //{
        //    TempData["Message"] = "You clicked SMS!";
        //    return RedirectToAction("Index");
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public void SendSMS(string from, string to, string message)
        //{
        //    var accountSid = "ACe81bca10cdbe61a732c48f916042ca30";
        //    var authToken = "3e880d05a7fb93a4bd3a000adc7af351";
        //    TwilioClient.Init(accountSid, authToken);
        //    try
        //    {
        //        MessageResource response = MessageResource.Create(
        //            body: message,
        //            from: from,
        //            to: to
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        public string GetMobileNumber(string mNum)
        {
            var APART_CODE_LOCAL_VAR = HttpContext.Request.Cookies["COMCODE"];
            string constr = _configuration.GetConnectionString("DBConnectionString");
            string mobileNumStr = "";

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT Mobile FROM AspNetUsers WHERE AspNetUsers.UserName='"+mNum+ "' AND ApartCodeName='" + APART_CODE_LOCAL_VAR + "' AND IsActive='true' AND IsLiving='true' AND Flat_No!='-' ";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mobileNumStr = sdr["Mobile"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            return mobileNumStr;
        }


        public List<SelectListItem> PopulateFlatOwners()
        {
            var APART_CODE_LOCAL_VAR = HttpContext.Request.Cookies["COMCODE"];
            string constr = _configuration.GetConnectionString("DBConnectionString");

            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT FirstName, LastName, Flat_No, Email FROM AspNetUsers WHERE ApartCodeName='" + APART_CODE_LOCAL_VAR + "' AND IsActive='true' AND IsLiving='true' AND Flat_No!='-'";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["FirstName"].ToString()+" "+ sdr["LastName"].ToString() + " (" + sdr["Flat_No"].ToString()+") ",
                                Value = sdr["Email"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }

    }
}
