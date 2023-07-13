using MinistryApp.Models;
using MinistryApp.Utility;
using MinistryApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ministry.Models;

namespace MinistryApp.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        const string APARTCODEVAR = "_ApartCodeSession";
        const string APARTCOMPANYNAME = "_ApartCompanyName";
        const string APARTCOMPANYLOGO = "_ApartCompanyLogo";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
                                SignInManager<ApplicationUser> signInManager, MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);
                
                if (result.Succeeded)
                {

                   var getValidUser = (from u in _context.Users
                                    where u.IsActive == true && u.Email== model.Email
                                       select u.UserName).FirstOrDefault();
                    if (getValidUser != null)
                    {
                        try
                        {
                            string userName = getValidUser;
                            
                        }
                        catch
                        {
                            
                        }

                        var getUserRole = (from u in _context.Users
                                           where u.IsActive == true && u.Email == model.Email
                                           select u.UserRole).FirstOrDefault();



                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            if (getUserRole == "Supervisor")
                            {
                                return RedirectToAction("ListUsers", "Administration");
                            }else if (getUserRole == "Admin")
                            {
                                return RedirectToAction("index", "Admin");
                            }
                            else if (getUserRole == "Chamber")
                            {
                                return RedirectToAction("index", "Chamber");
                            }
                            else
                            {
                                return RedirectToAction("index", "home");
                            }

                            

                         }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {

            if (!ModelState.IsValid)
                return View(forgotPasswordModel);
            var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
            {
                ViewBag.Message = "User not found!!";
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
               
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);
            BroadCast bc = new BroadCast();
            bc.sendBroadCastMail("EMAIL", user.Email, "Reset password token "+ callback,"Password Reset -NIBASH CORE", "");

            // var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
            // await _emailSender.SendEmailAsync(message);
            ViewBag.Message = "Successful!!";
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmationFailed));
            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }


        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmationFailed()
        {
            return View();
        }
        







        [AcceptVerbs("Get", "Post")]//[HttpGet][HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignOff()
        {
            await signInManager.SignOutAsync();
            //Remove("COMCODE");
            //Remove("COMNAME");
            //Remove("COMLOGO");
            return RedirectToAction("index", "home");
        }

        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ChamberRegister()
        {
            var _divisions = _context.DivisionsList.ToList();
            _divisions.Add(new DivisionsVM()
            {
                Id = 0,
                Name = "--Select Division--"
            });


            var _districts = new List<DistrictsVM>();
            _districts.Add(new DistrictsVM()
            {
                Id = 0,
                Name = "--Select District--"
            });

            var _Upzila = new List<UpazilasVM>();
            _Upzila.Add(new UpazilasVM()
            {
                Id = 0,
                Name = "--Select Upzila--"
            });

            var _Unions = new List<UnionsVM>();
            _Unions.Add(new UnionsVM()
            {
                Id = 0,
                Name = "--Select Thana--"
            });

            ViewData["DivisionData"] = new SelectList(_divisions.OrderBy(s => s.Id), "Id", "Name");
            ViewData["DistrictData"] = new SelectList(_districts.OrderBy(s => s.Id), "Id", "Name");
            ViewData["UpzilaData"] = new SelectList(_Upzila.OrderBy(s => s.Id), "Id", "Name");
            ViewData["UnionData"] = new SelectList(_Unions.OrderBy(s => s.Id), "Id", "Name");
            string host = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/";
            ViewData["BaseUrl"] = host;

            //var divisionListObj = (from c in _context.DivisionsList
            //                       select new SelectListItem()
            //                       {
            //                           Value = c.Id.ToString(),
            //                           Text = c.Name
            //                       }).ToList();
            //ViewBag.divisionList = divisionListObj;            

            //var districtListObj = (from c in _context.DistrictsList
            //                       select new SelectListItem()
            //                       {
            //                           Value = c.Id.ToString(),
            //                           Text = c.Name
            //                       }).ToList();
            //ViewBag.districtList = districtListObj;

            //var upazilaListObj = (from c in _context.UpazilasList
            //                       select new SelectListItem()
            //                       {
            //                           Value = c.Id.ToString(),
            //                           Text = c.Name
            //                       }).ToList();
            //ViewBag.upzillaList = upazilaListObj;

            //var unionListObj = (from c in _context.UnionsList
            //                      select new SelectListItem()
            //                      {
            //                          Value = c.Id.ToString(),
            //                          Text = c.Name
            //                      }).ToList();
            //ViewBag.unionList = unionListObj;


            var chamberListObj = (from c in _context.DropdownValues
                                  where c.EnumValueType== EnumValueType.CHAMBER_TYPE
                                  select new SelectListItem()
                                {
                                    Value = c.DropDownValue,
                                    Text = c.DropDownText
                                }).ToList();
            ViewBag.chamberList = chamberListObj;


            



            return View();
        }


        /// <summary>
        /// JSON DropDown
        /// </summary>
        /// <param name="model"></param>
        /// <param name="uploadFile"></param>
        /// <param name="LicenseAttachment"></param>
        /// <returns></returns>

        // GET: InventoryController/State/5
        //public JsonResult GetDistrictListByID(int divisionid)
        //{

        //    List<SelectListItem> getState = new List<SelectListItem>();
        //    var Getstateresult = _context.DistrictsList.Where(c => c.Division_id == divisionid).ToList(); 
            
        //    if (divisionid != 0)
        //    {
        //        return Json(Getstateresult);
        //        //return Json(new SelectList(Getstateresult, "Id", "Name"));
        //    }

        //    return null;
        //}
        //public JsonResult GetUpazilaList(int district_id)
        //{
        //    List<SelectListItem> UpazilaListItems = new List<SelectListItem>();
        //    var Getstateresult = _context.UpazilasList.Where(c => c.district_id == district_id).ToList();

        //    if (district_id != 0)
        //    {
        //        return Json(Getstateresult);
        //    }
        //    return null;
        //}


        [HttpPost, ActionName("GetDistrictsByDivisionId")]
        public JsonResult GetDistrictsByDivisionId(string divisionId)
        {
            int catId;
            List<DistrictsVM> listsObj = new List<DistrictsVM>();
            if (!string.IsNullOrEmpty(divisionId))
            {
                catId = Convert.ToInt32(divisionId);
                listsObj = _context.DistrictsList.Where(s => s.Division_id.Equals(catId)).ToList();
            }
            return Json(listsObj);
        }

        [HttpPost, ActionName("GetUpaziaByDistrictId")]
        public JsonResult GetUpaziaByDistrictId(string districtId)
        {
            int catId;
            List<UpazilasVM> listsObj = new List<UpazilasVM>();
            if (!string.IsNullOrEmpty(districtId))
            {
                catId = Convert.ToInt32(districtId);
                listsObj = _context.UpazilasList.Where(s => s.district_id.Equals(catId)).ToList();
            }
            return Json(listsObj);
        }


        [HttpPost, ActionName("GetUnionByUpzilaId")]
        public JsonResult GetUnionByUpzilaId(string upzilaId)
        {
            int catId;
            List<UnionsVM> listsObj = new List<UnionsVM>();
            if (!string.IsNullOrEmpty(upzilaId))
            {
                catId = Convert.ToInt32(upzilaId);
                listsObj = _context.UnionsList.Where(s => s.upazilla_id.Equals(catId)).ToList();
            }
            return Json(listsObj);
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ChamberRegister(RegisterViewModel model, IFormFile uploadFile, IFormFile LicenseAttachment)
        {
            ModelState.Clear();

            if (model.Division == "")
            {
                ModelState.AddModelError("", "Select Division");
            }
            if (model.District == "")
            {
                ModelState.AddModelError("", "Select District");
            }

            if (model.Upzila == "")
            {
                ModelState.AddModelError("", "Select Upzila");
            }

            if (model.Thana == "")
            {
                ModelState.AddModelError("", "Select Thana");
            }


            int validData = 0;

            if (ModelState.IsValid)
            {

                string uniqueFileName = null;
                if (uploadFile != null && uploadFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ProfilePicture");
                    uniqueFileName = DateTime.Now.ToString("yymmssfff") + "_" + Path.GetFileName(uploadFile.FileName);
                    // uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(fileStream);
                    }
                    model.ProfilePicture = uniqueFileName;
                    validData = 1;
                }
                else
                {
                    model.ProfilePicture = "no_picture.png";
                }


                string uniqueAttachName = null;
                if (LicenseAttachment != null && LicenseAttachment.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Files");
                    uniqueAttachName = DateTime.Now.ToString("yymmssfff") + "_" + Path.GetFileName(LicenseAttachment.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueAttachName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await LicenseAttachment.CopyToAsync(fileStream);
                    }
                    model.LicenseAttachment = uniqueAttachName;
                    validData = 1;
                }
                else
                {
                    model.LicenseAttachment = "no_picture.png";
                }





                if (validData == 1)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        TypesOfChambers = model.TypesOfChambers,
                        ChamberNo = model.ChamberNo,
                        Division = Convert.ToInt32(model.Division),
                        District = Convert.ToInt32(model.District),
                        Upzila = Convert.ToInt32(model.Upzila),
                        Thana = Convert.ToInt32(model.Thana),
                        PostalCode = model.PostalCode,
                        Per_Address = model.Per_Address,
                        LicenseNo = model.LicenseNo,
                        LicenseIssuedate = model.LicenseIssuedate,
                        LicenseStatus = model.LicenseStatus,
                        LicenseRevokeDate = model.LicenseRevokeDate,
                        LicenseAttachment = model.LicenseAttachment,
                        Remarks = model.Remarks,
                        UserRole = EnumRoleLists.Chamber.ToString(),
                        ProfilePicture = model.ProfilePicture,
                        IsActive = true
                    };

                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        var RoleFlatOwner = roleManager.FindByNameAsync(EnumRoleLists.Chamber.ToString()).Result;
                        if (RoleFlatOwner != null)
                        {
                            var roleresult = await userManager.AddToRoleAsync(user, EnumRoleLists.Chamber.ToString());
                        }

                        string smsBody = "Welcome .";
                        BroadCast nB = new BroadCast();
                        nB.sendBroadCastSMS("SMS", model.Mobile, smsBody);

                        if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                        {
                            return RedirectToAction("ListUsers", "Administration");
                        }
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {

                }


            }
            return View(model);
        }







        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        { 
    
            
         return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile uploadFile)
        {
            ModelState.Clear();
            int validData = 0;

            if (ModelState.IsValid)
            {

                string uniqueFileName = null;
                if (uploadFile != null && uploadFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ProfilePicture");
                    uniqueFileName = DateTime.Now.ToString("yymmssfff") + "_" + Path.GetFileName(uploadFile.FileName);
                    // uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(fileStream);
                    }
                    model.ProfilePicture = uniqueFileName;
                    validData = 1;
                }
                else
                {
                    model.ProfilePicture = "no_picture.png";
                }

               

                if (validData == 1)
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Mobile = model.Mobile,
                        NID = model.NID,
                        ETIN = model.ETIN,
                        PassportNo = model.PassportNo,
                        Per_Address = model.Per_Address,
                        pre_Address = model.pre_Address,
                        UserRole = EnumRoleLists.Chamber.ToString(),
                        ProfilePicture = model.ProfilePicture,
                        IsActive = true
                    };

                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        var RoleFlatOwner = roleManager.FindByNameAsync(EnumRoleLists.Chamber.ToString()).Result;
                        if (RoleFlatOwner != null)
                        {
                            var roleresult = await userManager.AddToRoleAsync(user, EnumRoleLists.Chamber.ToString());
                        }

                        string smsBody = "Welcome .";
                        BroadCast nB = new BroadCast();
                        nB.sendBroadCastSMS("SMS", model.Mobile, smsBody);

                        if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                        {
                            return RedirectToAction("ListUsers", "Administration");
                        }
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("index", "home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {

                }

                
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult SuperUserRegister()
        {
            return View();
        }


       

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SuperUserRegister(RegisterViewModel model, IFormFile uploadFile)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (uploadFile != null && uploadFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ProfilePicture");
                    uniqueFileName = DateTime.Now.ToString("yymmssfff") + "_" + Path.GetFileName(uploadFile.FileName);
                    // uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await uploadFile.CopyToAsync(fileStream);
                    }
                    model.ProfilePicture = uniqueFileName;
                  
                }
                else
                {
                    model.ProfilePicture = "no_picture.png";
                }


                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    NID = model.NID,
                    ETIN = model.ETIN,
                    PassportNo = model.PassportNo,
                    Per_Address = model.Per_Address,
                    pre_Address = model.pre_Address,
                    UserRole = EnumRoleLists.Admin.ToString(),
                    ProfilePicture = model.ProfilePicture,
                    IsActive = true

                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                   var RoleFlatOwner = roleManager.FindByNameAsync(EnumRoleLists.Admin.ToString()).Result;
                   if (RoleFlatOwner != null)
                   {
                       var roleresult = await userManager.AddToRoleAsync(user, EnumRoleLists.Admin.ToString());
                   }

                   if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }



    }
}
