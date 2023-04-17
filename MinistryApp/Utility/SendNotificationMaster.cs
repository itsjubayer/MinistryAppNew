using MinistryApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.Utility
{
    public class SendNotificationMaster
    {

        private readonly MinistryDBContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        public IConfiguration _configuration;
        
        //public SendNotificationMaster()
        //{

        //, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, IConfiguration configuration


        //}

        public SendNotificationMaster(MinistryDBContext context)
        {
            _context = context;
            //this._userManager = userManager;
            //_configuration = configuration;
        }


        public void SendNotificationType(string type, string roleName, string textBody, string emailSubject)
        {
            var users = (from user in _context.Users
                         join userRole in _context.UserRoles
                         on user.Id equals userRole.UserId
                         join role in _context.Roles
                         on userRole.RoleId equals role.Id
                         where role.Name == roleName
                         select user).ToList();
            BroadCast nB = new BroadCast();
            foreach (var item in users)
            {
                string e_mobile = item.Mobile;
                string e_mail = item.Email;
                if(type== "Email")
                {
                    nB.sendBroadCastMail("Email", e_mail, textBody, emailSubject);
                }else if(type == "SMS")
                {
                    nB.sendBroadCastSMS("SMS", e_mobile, textBody);
                }            
                
            }

        }




        //string textBody = "";
        //string textSubject = "";
        //SendNotification("Committee", textBody, textSubject);
        //SendNotification("Treasurer", textBody, textSubject);
        //OwnerNotification(processVM.FlatNo, textBody, textSubject);

        /// <summary>
        /// Send notification by apartment code
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="roleName"></param>
        /// <param name="textBody"></param>
        /// <param name="emailSubject"></param>
        /// <param name="attachedFile"></param>
        public void SendNotification(string msgType, string roleName, string apartCode, string textBody, string emailSubject, string attachedFile = "")
        {
            var users = (from user in _context.Users
                         join userRole in _context.UserRoles
                         on user.Id equals userRole.UserId
                         join role in _context.Roles
                         on userRole.RoleId equals role.Id
                         select user).ToList();

            if (roleName != "")
            {
                users = (from user in _context.Users
                         join userRole in _context.UserRoles
                         on user.Id equals userRole.UserId
                         join role in _context.Roles
                         on userRole.RoleId equals role.Id
                         where role.Name == roleName
                         select user).ToList();

            }

            BroadCast nB = new BroadCast();

            foreach (var item in users)
            {
                string e_mobile = item.Mobile;
                string e_mail = item.Email;

                if (msgType == "Email")
                {
                    nB.sendBroadCastMail(msgType, e_mail, textBody, emailSubject, attachedFile);
                }
                if (msgType == "SMS")
                {
                    nB.sendBroadCastSMS(msgType, e_mobile, textBody);
                }
                else if (msgType == "All")
                {
                    nB.sendBroadCastMail("Email", e_mail, textBody, emailSubject, attachedFile);
                    nB.sendBroadCastSMS("SMS", e_mobile, textBody);
                }
            }

        }

        


        public void SendNotification(string msgType, string roleName, string textBody, string emailSubject, string attachedFile="")
        {
           var users = (from user in _context.Users
                     join userRole in _context.UserRoles
                     on user.Id equals userRole.UserId
                     join role in _context.Roles
                     on userRole.RoleId equals role.Id
                     select user).ToList();

            if (roleName != "")
            {
                 users = (from user in _context.Users
                             join userRole in _context.UserRoles
                             on user.Id equals userRole.UserId
                             join role in _context.Roles
                             on userRole.RoleId equals role.Id
                             where role.Name == roleName
                             select user).ToList();

            }

            BroadCast nB = new BroadCast();
            
            foreach (var item in users)
            {
                string e_mobile = item.Mobile;
                string e_mail = item.Email;

                if(msgType== "Email")
                {
                    nB.sendBroadCastMail(msgType, e_mail, textBody, emailSubject, attachedFile);
                }
                if (msgType == "SMS")
                {
                    nB.sendBroadCastSMS(msgType, e_mobile, textBody);
                }else if(msgType == "All")
                {
                    nB.sendBroadCastMail("Email", e_mail, textBody, emailSubject, attachedFile);
                    nB.sendBroadCastSMS("SMS", e_mobile, textBody);
                }
            }

        }


        


        


        

    }
}
