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
            //Get Chamber Users
            var getChamberList = (from c in _context.Users.Where(p =>p.UserRole=="Chamber" && p.IsActive == true)
                                  select new SelectListItem()
                                  {
                                      Value = c.UserName,
                                      Text = c.FirstName
                                  }).ToList();

            ViewBag.chamberList = getChamberList;



            var _divisions = _context.DivisionsList.ToList();
            _divisions.Add(new DivisionsVM()
            {
                Id = 0,
                Name = "--Select Division--"
            });
            var _districts = new List<DistrictsVM>();
            _districts.Add(new DistrictsVM()
            {
                Id = 0,
                Name = "--Select District--"
            });

            var _Upzila = new List<UpazilasVM>();
            _Upzila.Add(new UpazilasVM()
            {
                Id = 0,
                Name = "--Select Upzila--"
            });

            var _Unions = new List<UnionsVM>();
            _Unions.Add(new UnionsVM()
            {
                Id = 0,
                Name = "--Select Thana--"
            });

            ViewData["DivisionData"] = new SelectList(_divisions.OrderBy(s => s.Id), "Id", "Name");
            ViewData["DistrictData"] = new SelectList(_districts.OrderBy(s => s.Id), "Id", "Name");
            ViewData["UpzilaData"] = new SelectList(_Upzila.OrderBy(s => s.Id), "Id", "Name");
            ViewData["UnionData"] = new SelectList(_Unions.OrderBy(s => s.Id), "Id", "Name");
            string host = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/";
            ViewData["BaseUrl"] = host;


            var designationListObj = (from c in _context.DropdownValues
                                  where c.EnumValueType == EnumValueType.DESIGNATION
                                  select new SelectListItem()
                                  {
                                      Value = c.DropDownValue,
                                      Text = c.DropDownText
                                  }).ToList();
            ViewBag.designationList = designationListObj;


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
            valObj.Status = "Active";
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
