using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ministry.Models;
using MinistryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Controllers
{
    public class MemberInfoController : Controller
    {
        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MemberInfoController(MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: EnumValues
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MemberInfoList.Where(e => e.IsActive == true).ToListAsync());
        }

        // GET: EnumValues/Create
        [Authorize]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new MemberInfoVM());
            else
                return View(_context.MemberInfoList.Find(id));
        }

        // POST: EnumValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(MemberInfoVM valObj)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                if (valObj.Id == 0)
                    _context.Add(valObj);
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
            var valObj = await _context.MemberInfoList.FindAsync(id);
            _context.MemberInfoList.Remove(valObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
