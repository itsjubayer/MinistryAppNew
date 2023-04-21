using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ministry.Models;
using MinistryApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ministry.Controllers
{
    public class FileModelController : Controller
    {

        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public FileModelController(MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Flat
        public IActionResult Index()
        {
            return View();
        }


        // GET: Flat
        public async Task<IActionResult> ListFilesRows()
        {
            return View(await _context.FilesList.Where(p => p.IsActive == true).ToListAsync());
        }

        public IActionResult OpenDummyData()
        {
            return View();
        }


        // GET: EnumValues/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var categoryListObj = (from c in _context.FileCategoryList.Where(p => p.IsActive==true)
                                       select new SelectListItem()
                                       {
                                           Value = c.FileCategoryName.ToString(),
                                           Text = c.FileCategoryValue
                                       }).ToList();

            ViewBag.categoryList = categoryListObj;
            

            if (id == 0)
                return View(new FileModelVM());
            else
                return View(_context.FilesList.Find(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(FileModelVM fileModelObj)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
           

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (fileModelObj.Id == 0)
                {

                    var GetChamberUserList = _context.Users
                                                .Where(p => p.UserRole== "Chamber" && p.IsActive == true)
                                                .Select(p => new { p.Id, p.UserName}).ToList();

                    foreach (var valStr in GetChamberUserList)
                    {
                        FileModelVM fileCreatedForChambersObj = new FileModelVM();
                        fileCreatedForChambersObj.ResonsiblePerson = valStr.UserName;

                        fileCreatedForChambersObj.FileCategory = fileModelObj.FileCategory;
                        fileCreatedForChambersObj.DateLine = fileModelObj.DateLine;
                        fileCreatedForChambersObj.CreatedBy = userName;
                        fileCreatedForChambersObj.CreatedDate = DateTime.Now;
                        fileCreatedForChambersObj.SubmitStatus = "Pending";
                        
                        fileCreatedForChambersObj.IsActive = true;
                        _context.Add(fileCreatedForChambersObj);
                    }



                    
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileModelObj);
        }



        // GET: EnumValues/Create
        public IActionResult Details(int id = 0)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var categoryListObj = (from c in _context.FileCategoryList.Where(p => p.IsActive == true)
                                   select new SelectListItem()
                                   {
                                       Value = c.FileCategoryName.ToString(),
                                       Text = c.FileCategoryValue
                                   }).ToList();

            ViewBag.categoryList = categoryListObj;


            if (id == 0)
                return View(new FileModelVM());
            else
                return View(_context.FilesList.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(FileModelVM fileModelObj)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);


            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (fileModelObj.Id == 0)
                {

                    var GetChamberUserList = _context.Users
                                                .Where(p => p.UserRole == "Chamber" && p.IsActive == true)
                                                .Select(p => new { p.Id, p.UserName }).ToList();

                    foreach (var valStr in GetChamberUserList)
                    {
                        FileModelVM fileCreatedForChambersObj = new FileModelVM();
                        fileCreatedForChambersObj.ResonsiblePerson = valStr.UserName;

                        fileCreatedForChambersObj.FileCategory = fileModelObj.FileCategory;
                        fileCreatedForChambersObj.DateLine = fileModelObj.DateLine;
                        fileCreatedForChambersObj.CreatedBy = userName;
                        fileCreatedForChambersObj.CreatedDate = DateTime.Now;
                        fileCreatedForChambersObj.SubmitStatus = "Pending";

                        fileCreatedForChambersObj.IsActive = true;
                        _context.Add(fileCreatedForChambersObj);
                    }




                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileModelObj);
        }



        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var values = await _context.FilesList.FindAsync(id);
            values.IsActive = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DownloadFile(string filePath)
        {

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            string fileName = "myfile.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            //For preview pdf and the download it use below code
            // var stream = new FileStream(filePath, FileMode.Open);
            //return new FileStreamResult(stream, "application/pdf");
        }

    }
}
