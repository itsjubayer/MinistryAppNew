using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UserController : Controller
    {
        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UserController(MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Flat
        public async Task<IActionResult> Index()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);

            return View(await _context.FilesList.Where(p => p.ResonsiblePerson== userName && p.IsActive == true).ToListAsync());
        }


        // GET: EnumValues/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);


            if (id == 0)
                return View(new FileModelVM());
            else
                return View(_context.FilesList.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(FileModelVM fileModelObj, IFormFile FileAttachment)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            try
            {
                string uniqueFileName = null;
                if (FileAttachment != null && FileAttachment.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Files");
                    uniqueFileName = DateTime.Now.ToString("yymmssfff") + "_" + Path.GetFileName(FileAttachment.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await FileAttachment.CopyToAsync(fileStream);
                    }
                    fileModelObj.Attachment = uniqueFileName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (fileModelObj.Id == 0)
                {

                    

                }
                else
                {
                    //fileModelObj.FileName = fileModelObj.FileName;
                    //fileModelObj.FileType = "PDF";
                    //fileModelObj.SubmittedBy = userName;
                    //fileModelObj.SubmittedDate = DateTime.Now;
                    //fileModelObj.SubmitStatus = "Submitted";
                    //_context.Update(fileModelObj);

                    var values = await _context.FilesList.FindAsync(fileModelObj.Id);
                    values.FileName = fileModelObj.FileName;
                    values.Attachment = fileModelObj.Attachment;
                    values.FileType = "PDF";
                    values.SubmittedBy = userName;
                    values.SubmittedDate = DateTime.Now;
                    values.SubmitStatus = "Submitted";

                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileModelObj);
        }

        

    }
}
