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
    public class Exercise_MuscleController : Controller
    {
        private readonly app_context _context;

        public Exercise_MuscleController(app_context context)
        {
            _context = context;
        }

        // GET: Exercise_Muscle
        public async Task<IActionResult> Index()
        {
            var app_context = _context.Exercise_Muscle.Include(e => e.exercise);
            return View(await app_context.ToListAsync());
        }

        // GET: Exercise_Muscle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise_Muscle = await _context.Exercise_Muscle
                .Include(e => e.exercise)
                .FirstOrDefaultAsync(m => m.id == id);
            if (exercise_Muscle == null)
            {
                return NotFound();
            }

            return View(exercise_Muscle);
        }

        //previeus File path : C:\Users\hen-t\Desktop\PersonalTraining_DateFiles\Muscle_Exercsis.csv
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
                Exercise_Muscle em= new Exercise_Muscle(dt.Rows[i]);
                em.exercise = _context.Exercise.FirstOrDefault(e => e.id ==em.exerciseId );
                em.muscle = _context.Muscles.FirstOrDefault(e => e.id ==em.muscleId );
                _context.Exercise_Muscle.Add(em);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }














        //--------------------------------------------------CRUD

        // GET: Exercise_Muscle/Create
        public IActionResult Create()
        {
            ViewData["exerciseId"] = new SelectList(_context.Exercise, "id", "id");
            return View();
        }

        // POST: Exercise_Muscle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,musclesId,exerciseId")] Exercise_Muscle exercise_Muscle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise_Muscle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["exerciseId"] = new SelectList(_context.Exercise, "id", "id", exercise_Muscle.exerciseId);
            return View(exercise_Muscle);
        }

        // GET: Exercise_Muscle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise_Muscle = await _context.Exercise_Muscle.FindAsync(id);
            if (exercise_Muscle == null)
            {
                return NotFound();
            }
            ViewData["exerciseId"] = new SelectList(_context.Exercise, "id", "id", exercise_Muscle.exerciseId);
            return View(exercise_Muscle);
        }

        // POST: Exercise_Muscle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,musclesId,exerciseId")] Exercise_Muscle exercise_Muscle)
        {
            if (id != exercise_Muscle.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise_Muscle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exercise_MuscleExists(exercise_Muscle.id))
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
            ViewData["exerciseId"] = new SelectList(_context.Exercise, "id", "id", exercise_Muscle.exerciseId);
            return View(exercise_Muscle);
        }

        // GET: Exercise_Muscle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise_Muscle = await _context.Exercise_Muscle
                .Include(e => e.exercise)
                .FirstOrDefaultAsync(m => m.id == id);
            if (exercise_Muscle == null)
            {
                return NotFound();
            }

            return View(exercise_Muscle);
        }

        // POST: Exercise_Muscle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise_Muscle = await _context.Exercise_Muscle.FindAsync(id);
            _context.Exercise_Muscle.Remove(exercise_Muscle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exercise_MuscleExists(int id)
        {
            return _context.Exercise_Muscle.Any(e => e.id == id);
        }
    }
}
