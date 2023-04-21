using MinistryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ministry.Models;

namespace MinistryApp.Controllers
{
    public class FAQController : Controller
    {
        private readonly MinistryDBContext _context;

        public FAQController(MinistryDBContext context)
        {
            _context = context;
        }

        // GET: Flat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Faqs.ToListAsync());
        }

        public async Task<IActionResult> ViewFAQ()
        {
            return View(await _context.Faqs.ToListAsync());
        }

        // GET: Flat/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new FAQVM());
            else
                return View(_context.Faqs.Find(id));
        }


        // GET: Flat
        public async Task<IActionResult> FaqView()
        {
            return View(await _context.Faqs.ToListAsync());
        }



        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FaqTitle,FaqDescription,EntryBy")] FAQVM faqVM)
        {
            faqVM.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (faqVM.Id == 0)
                    _context.Add(faqVM);
                else
                    _context.Update(faqVM);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faqVM);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valObj = await _context.Faqs.FindAsync(id);
            _context.Faqs.Remove(valObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public JsonResult Create1(string prefix)
        {
            var courseList = (from N in _context.Faqs.ToList()
                              where N.FaqTitle.StartsWith(prefix)
                              select new { N.FaqTitle });
            return Json(courseList);
        }

    }
}
