using Microsoft.AspNetCore.Authorization;
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
    public class FileCategoryController : Controller
    {
        private readonly MinistryDBContext _context;

        public FileCategoryController(MinistryDBContext context)
        {
            _context = context;
        }

        // GET: EnumValues
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileCategoryList.ToListAsync());
        }

        // GET: EnumValues/Create
        [Authorize]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new FileCategoryVM());
            else
                return View(_context.FileCategoryList.Find(id));
        }

        // POST: EnumValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(FileCategoryVM fileCategoryObj)
        {
            ModelState.Clear();
            
            if (ModelState.IsValid)
            {
                if (fileCategoryObj.Id == 0)
                {
                    fileCategoryObj.FileCategoryName = fileCategoryObj.FileCategoryName;
                    fileCategoryObj.FileCategoryValue = fileCategoryObj.FileCategoryName;
                    _context.Add(fileCategoryObj);

                }
                else
                {
                    fileCategoryObj.FileCategoryName = fileCategoryObj.FileCategoryName;
                    fileCategoryObj.FileCategoryValue = fileCategoryObj.FileCategoryName;
                    _context.Update(fileCategoryObj);
                }
                    
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileCategoryObj);
        }

        // GET: Bill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var EnumModel = await _context.FileCategoryList.FindAsync(id);
            _context.FileCategoryList.Remove(EnumModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
