using Microsoft.AspNetCore.Mvc;
using Ministry.Models;
using MinistryApp.Models;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Ministry.Controllers
{
    public class GalleryController : Controller
    {
        private readonly MinistryDBContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public IConfiguration _configuration;


        public GalleryController(MinistryDBContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Flat
        public async Task<IActionResult> Index()
        {
            return View(await _context.GalleryList.ToListAsync());
        }

        public async Task<IActionResult> ViewGallery()
        {
            return View(await _context.GalleryList.Where(e=>e.IsActive==true).ToListAsync());
        }



        // GET: Flat/Create
        public IActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new GalleryVM());
            else
                return View(_context.GalleryList.Find(id));
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(GalleryVM Obj)
        {
            string uniqueFileName = string.Empty;
            Obj.Date = DateTime.Now;
            Obj.EntryBy = User.Identity.Name != "" ? User.Identity.Name : "-";
            if (ModelState.IsValid)
            {
                try
                {

                    uniqueFileName = GetUniqueFileName(Obj.Image.FileName);
                    var dir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/gallery");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var filePath = Path.Combine(dir, uniqueFileName);
                    await Obj.Image.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                Obj.ImageName = uniqueFileName;
                if (Obj.Id == 0)
                    _context.Add(Obj);
                else
                    _context.Update(Obj);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Obj);
        }


        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }


        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valObj = await _context.GalleryList.FindAsync(id);
            _context.GalleryList.Remove(valObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
