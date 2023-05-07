using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ministry.Models;
using MinistryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Controllers
{
    public class TypesOfReportsController : Controller
    {
        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TypesOfReportsController(MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: EnumValues
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypesOfReports.Where(e => e.IsActive == true).ToListAsync());
        }

        // GET: EnumValues/Create
        [Authorize]
        public IActionResult AddOrEdit(int id = 0)
        {
            
            ViewBag.FreqOfReport = new SelectList(Enum.GetValues(typeof(FreqOfReport)));
            if (id == 0)
                return View(new TypesOfReportVM());
            else
                return View(_context.TypesOfReports.Find(id));
        }

        // POST: EnumValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(TypesOfReportVM reportObj)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (reportObj.Id == 0)
                    _context.Add(reportObj);
                else
                    _context.Update(reportObj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportObj);
        }

        // GET: Bill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var valObj = await _context.TypesOfReports.FindAsync(id);
            _context.TypesOfReports.Remove(valObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
