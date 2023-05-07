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
    public class ChamberController : Controller
    {
        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ChamberController(MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            //var userName = User.FindFirstValue(ClaimTypes.Name);
            //ViewBag.Chamber_Name = userName;
            //BillCount
            ViewBag.Pending = GetValueByStatus("Pending");
            ViewBag.Progress = GetValueByStatus("Progress");
            ViewBag.Submit = GetValueByStatus("Submitted");


            return View();
        }

        public Double GetValueByStatus(string val)
        {

            var userName = User.FindFirstValue(ClaimTypes.Name);
            int countValue = (from row in _context.SubmittedFiles
                                         where row.File_Submit_Status== val
                                         where row.IsActive== true
                                         where row.chamber_username== userName
                              select row).Count();
            return countValue;
        }

        //[HttpGet("{id}/{first}/{second}")]
        [HttpGet("FileRequestList")]
        public async Task<IActionResult> FileRequestList(String? fileStr)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            return View(await _context.SubmittedFiles.Where(e => e.IsActive == true && e.File_Submit_Status==fileStr && e.chamber_username== userName).ToListAsync());
        }


        // GET: EnumValues/Create
        public IActionResult SubmitFile(int id = 0)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name); 

            if (id == 0)
                return View(new SubmittedFileVM());
            else
                return View(_context.SubmittedFiles.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitFile(SubmittedFileVM submitFileObj, IFormFile submitFile)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);


            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (submitFileObj.Id == 0)
                {


                    _context.Add(submitFileObj);

                }
                else
                {
                    if (submitFile != null)
                    {

                        //Set Key Name
                        string file_ = Guid.NewGuid().ToString() + Path.GetExtension(submitFile.FileName);

                        //Get url To Save
                        string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", file_);

                        using (var stream = new FileStream(SavePath, FileMode.Create))
                        {
                            submitFile.CopyTo(stream);
                        }

                        submitFileObj.Submission_Date = DateTime.Now;
                        submitFileObj.File_Submit_Status = "Submitted";
                        submitFileObj.Attachment = file_;
                        submitFileObj.TypesOfReport=null;

                        ////submitFileObj.TypesOfReport.Frequency_Of_Report = "Daily";
                        ////submitFileObj.TypesOfReport.Remarks = "";
                    }
                    
                    _context.Update(submitFileObj);
                }
                    
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submitFileObj);
        }

        

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var values = await _context.SubmittedFiles.FindAsync(id);
            values.IsActive = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DownloadFile(string fileName)
        {
            // Since this is just and example, I am using a local file located inside wwwroot
            // Afterwards file is converted into a stream
            var path = Path.Combine(_hostingEnvironment.WebRootPath, fileName);
            var fs = new FileStream(path, FileMode.Open);

            // Return the file. A byte array can also be used instead of a stream
            return File(fs, "application/octet-stream", fileName);
        }

    }
}
