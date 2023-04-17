using MinistryApp.Models;
using MinistryApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinistryApp.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;


        const string APARTCODEVAR = "_ApartCodeSession";
        const string APARTCOMPANYNAME = "_ApartCompanyName";
        const string APARTCOMPANYLOGO = "_ApartCompanyLogo";

        private readonly IStringLocalizer<HomeController> _stringLocalizer;

        private readonly ILogger<HomeController> _logger;

        private readonly MinistryDBContext _context;

        public HomeController(ILogger<HomeController> logger, MinistryDBContext context, IStringLocalizer<HomeController> stringLocalizer, IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _context = context;
            _stringLocalizer = stringLocalizer;
            _localizer = localizer;
        }



        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index(string SearchDate)//, DateTime? startdate, DateTime? enddate
        {
            ViewData["PageTitle"] = _stringLocalizer["page.title"].Value;
            ViewData["PageDesc"] = _stringLocalizer["page.description"].Value;
            
            int searchDateParam = Convert.ToInt32(SearchDate);

            

            ViewBag.SearchDate = searchDateParam;


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            // return RedirectToAction(nameof(Index));
            return LocalRedirect(returnUrl);
        }

    }
}
