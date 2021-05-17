using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalTrainerApp.Data;
using PersonalTrainerApp.Models;
using PersonalTrainerApp.ViewModels;

namespace PersonalTrainerApp.Controllers
{
    public class MusclesController : Controller
    {
        private readonly app_context _context;

        public MusclesController(app_context context)
        {
            _context = context;
        }

        // GET: Muscles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Muscles.ToListAsync());
        }

        //previeus File path : C:\Users\hen-t\Desktop\PersonalTraining_DateFiles\Muscles.csv
        //UploadDataFiles_ViewModel

        [HttpGet]
        public IActionResult UploadFile()
        {

            UploadDataFiles_ViewModel vm = new ViewModels.UploadDataFiles_ViewModel();
            return View("UploadData", vm);

        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadDataFiles_ViewModel vm)
        {
            string fileName = vm.fileName;
            DataTable dt = IO.ReadCsvFile(fileName);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                Muscle mu = new Muscle(dt.Rows[i]);
                _context.Muscles.Add(mu);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Build_TrainingProgram(TraineeRegister_Muscles_ViewModel vm)
        {
            return View();
        }

        






        //--------------------------------------------------CRUD

        // GET: Muscles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles
                .FirstOrDefaultAsync(m => m.id == id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        // GET: Muscles/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,HebrewName")] Muscle muscle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muscle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muscle);
        }

        // GET: Muscles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles.FindAsync(id);
            if (muscle == null)
            {
                return NotFound();
            }
            return View(muscle);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,HebrewName")] Muscle muscle)
        {
            if (id != muscle.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muscle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuscleExists(muscle.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(muscle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muscle = await _context.Muscles
                .FirstOrDefaultAsync(m => m.id == id);
            if (muscle == null)
            {
                return NotFound();
            }

            return View(muscle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muscle = await _context.Muscles.FindAsync(id);
            _context.Muscles.Remove(muscle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuscleExists(int id)
        {
            return _context.Muscles.Any(e => e.id == id);
        }


        
    }
}
