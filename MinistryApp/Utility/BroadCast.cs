using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MinistryApp.Utility
{
    public class BroadCast
    {
        public void sendBroadCastMail(string broadCastType, string txtReceiver, string txtMsgBody, string emailSubject, string attachedFile="")
        {
            
            String msgBody = "";
            try
            {
                msgBody = txtMsgBody.ToString();
            }
            catch (Exception ex)
            {

            }
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("elongatesdev@gmail.com");
                    mail.To.Add(txtReceiver);
                    mail.Subject = emailSubject;
                    mail.Body = msgBody;
                    mail.IsBodyHtml = true;

                    if (attachedFile != null && attachedFile != "")
                    {
                        mail.Attachments.Add(new Attachment(attachedFile));
                    }


                    //  mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("elongatesdev@gmail.com", "aqitzohxddzutnve");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
                
        }

        public bool sendBroadCastSMS(string broadCastType, string receivers, string txtMsgBody)
        {
            try
            {
                SendSMS(receivers, txtMsgBody);
                //SendSMS("+18106921420", receivers, txtMsgBody);
                return true;
            }catch(Exception ex)
            {
                return false;
            }

 
        }

        public void SendSMS(string from, string to, string message)
        {
            var accountSid = "ACe81bca10cdbe61a732c48f916042ca30";
            var authToken = "3e880d05a7fb93a4bd3a000adc7af351";
            TwilioClient.Init(accountSid, authToken);
            try
            {
                MessageResource response = MessageResource.Create(
                    body: message,
                    from: from,
                    to: to
                );
            }
            catch (Exception ex)
            {
            }
        }


        public void SendSMS(string mobNumber, string textMessage)
        {
            using (var client = new HttpClient())
            {
                string API_Url = "http://sms.felnadma.com/api/v1/send";
                string API_Key = "44516430986385661643098638";
                string Text_Massage = textMessage;
                string To_Phone_Number = mobNumber;
                string senderID = "8801847431161";
                client.BaseAddress = new Uri(API_Url);// //
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("?api_key=" + API_Key + "&contacts=" + To_Phone_Number + "& senderid="+ senderID + "&msg=" + Text_Massage).Result;
                using (HttpContent content = response.Content)
                {
                    var bkresult = content.ReadAsStringAsync().Result;
                    dynamic stuff = JsonConvert.DeserializeObject(bkresult);
                    if (stuff.error == "0")
                    {
                        Console.WriteLine(stuff.msg);
                    }
                    else
                    {
                        Console.WriteLine("Sms Not Send, " + stuff.msg);
                    }

                }
            }
        }

    }
}
