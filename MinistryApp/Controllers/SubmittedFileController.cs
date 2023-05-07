using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ministry.Models;
using MinistryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ministry.Controllers
{
    public class SubmittedFileController : Controller
    {
        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SubmittedFileController(MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: EnumValues
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubmittedFiles.Where(e => e.IsActive == true).ToListAsync());
        }

        // GET: EnumValues/Create
        [Authorize]
        public IActionResult AddOrEdit(int id = 0)
        {

            var reportTypeList = (from c in _context.TypesOfReports.Where(p => p.IsActive==true)
                                       select new SelectListItem()
                                       {
                                           Value = c.Id.ToString(),
                                           Text = c.Report_Type_Name
                                       }).ToList();

            ViewBag.reportTypeList = reportTypeList;


            if (id == 0)
                return View(new SubmittedFileVM());
            else
                return View(_context.SubmittedFiles.Find(id));
        }

        // POST: EnumValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(SubmittedFileVM valObj, IFormFile FileAttachment)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);


            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (valObj.Id == 0)
                {
                    var GetChamberUserList = _context.Users
                                                .Where(p => p.UserRole == "Chamber" && p.IsActive == true)
                                                .Select(p => new { p.Id, p.UserName }).ToList();

                    foreach (var valStr in GetChamberUserList)
                    {
                        SubmittedFileVM fileCreatedForChambersObj = new SubmittedFileVM();
                        fileCreatedForChambersObj.chamber_username = valStr.UserName;
                        //fileCreatedForChambersObj.Chamber_Id = Convert.ToInt32(valStr.Id);

                        fileCreatedForChambersObj.Report_Type_Id = valObj.Report_Type_Id;
                        fileCreatedForChambersObj.DeadLine = valObj.DeadLine;
                        fileCreatedForChambersObj.CreatedBy = userName;
                        fileCreatedForChambersObj.File_Submit_Status = "Pending";

                        fileCreatedForChambersObj.IsActive = true;
                        _context.Add(fileCreatedForChambersObj);
                    }
                }
                    //_context.Add(valObj);
                else
                    _context.Update(valObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(valObj);
        }

        // GET: Bill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var valObj = await _context.SubmittedFiles.FindAsync(id);
            _context.SubmittedFiles.Remove(valObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
