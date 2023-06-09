﻿using Microsoft.AspNetCore.Authorization;
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
    public class DropdownController : Controller
    {
        private readonly MinistryDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DropdownController(MinistryDBContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }


        // GET: EnumValues
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.DropdownValues.Where(e => e.IsActive == true).ToListAsync());
        }

        // GET: EnumValues/Create
        [Authorize]
        public IActionResult AddOrEdit(int id = 0)
        {
            ViewBag.ENUMTYPES = new SelectList(Enum.GetValues(typeof(EnumValueType)));
            if (id == 0)
                return View(new DropDownValuesVM());
            else
                return View(_context.DropdownValues.Find(id));
        }

        // POST: EnumValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(DropDownValuesVM enumModel)
        { ModelState.Clear();
            if (ModelState.IsValid)
            {
                enumModel.DropDownValue = enumModel.DropDownText;
                if (enumModel.Id == 0)
                    _context.Add(enumModel);
                else
                    _context.Update(enumModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enumModel);
        }

        // GET: Bill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var EnumModel = await _context.DropdownValues.FindAsync(id);
            _context.DropdownValues.Remove(EnumModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
