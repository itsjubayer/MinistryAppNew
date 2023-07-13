using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ministry.Models;
using MinistryApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.Controllers
{
    public class ELearningController : Controller
    {
        private readonly MinistryDBContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public IConfiguration _configuration;


        public ELearningController(MinistryDBContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ELearningList.ToListAsync());
        }


        public async Task<IActionResult> ELearningView()
        {
            return View(await _context.ELearningList.Where(e=>e.IsActive==true).ToListAsync());
        }




        // GET: Flat/Create
        public IActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
                return View(new ELearningVM());
            else
                return View(_context.ELearningList.Find(id));
        }



        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(ELearningVM Obj)
        {
            string uniqueFileName = string.Empty;
            Obj.CreateDate = DateTime.Now;
            Obj.CreatedBy = User.Identity.Name != "" ? User.Identity.Name : "-";
            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (Obj.Id == 0)
                        _context.Add(Obj);
                    else
                        _context.Update(Obj);

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                
            }
            return View(Obj);
        }


        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valObj = await _context.ELearningList.FindAsync(id);
            _context.ELearningList.Remove(valObj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
