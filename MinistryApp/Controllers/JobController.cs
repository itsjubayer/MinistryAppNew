using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ministry.Models;
using MinistryApp.Models;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;

namespace Ministry.Controllers
{
    public class JobController : Controller
    {
        private readonly MinistryDBContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public IConfiguration _configuration;


        public JobController(MinistryDBContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.JobList.ToListAsync());
        }

        public async Task<IActionResult> ViewJobs()
        {
            return View(await _context.JobList.Where(e=>e.IsActive==true).ToListAsync());
        }


        

        // GET: Flat/Create
        public IActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new JobVM());
            else
                return View(_context.JobList.Find(id));
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(JobVM Obj)
        {
            string uniqueFileName = string.Empty;
            
            
                try
                {
                    try
                    {
                        uniqueFileName = GetUniqueFileName(Obj.Image.FileName);
                        var dir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/job_image");
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

                    //if (ModelState.IsValid)
                    //{
                        if (Obj.Id == 0)
                            _context.Add(Obj);
                        else
                            _context.Update(Obj);

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    //}
                }
                catch (Exception ex)
                 {
                     Console.WriteLine(ex.ToString());
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

            var valObj = await _context.JobList.FindAsync(id);
            _context.JobList.Remove(valObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
