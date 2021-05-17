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
    public class ExercisesController : Controller
    {
        private readonly app_context _context;

        public ExercisesController(app_context context)
        {
            _context = context;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exercise.ToListAsync());
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(m => m.id == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }



        //previeus File path : C:\Users\hen-t\Desktop\PersonalTraining_DateFiles/Exercsis.csv

        [HttpGet]
        public IActionResult UploadFile()
        {

            UploadDataFiles_ViewModel vm = new ViewModels.UploadDataFiles_ViewModel();
            return View("UploadData", vm);

        }
        //UploadDataFiles_ViewModel
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadDataFiles_ViewModel vm)
        {
            // string fileName = "C:\\Users\\hen-t\\source\repos\\PersonalTrainerApp\\Files\\Exercsis.csv";
            // UploadDataFiles_ViewModel vm = new ViewModels.UploadDataFiles_ViewModel() { fileName = fileName };

            string fileName = vm.fileName;
            DataTable dt = IO.ReadCsvFile(fileName);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                Exercise ex = new Exercise(dt.Rows[i]);
                _context.Exercise.Add(ex);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }









        //--------------------------------------------------CRUD

        // GET: Exercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,max_whight,min_whight")] Exercise exercise)
        {
            if (id != exercise.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists(exercise.id))
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
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(m => m.id == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercise.FindAsync(id);
            _context.Exercise.Remove(exercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercise.Any(e => e.id == id);
        }




      
    }
}
