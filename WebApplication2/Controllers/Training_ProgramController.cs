using System;
using System.Collections.Generic;
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
    public class Training_ProgramController : Controller
    {
        private readonly app_context _context;

        public Training_ProgramController(app_context context)
        {
            _context = context;
        }

        // GET: Training_Program
        public async Task<IActionResult> Index()
        {
            var app_context = _context.Training_Program.Include(t => t.trainee);
            return View(await app_context.ToListAsync());
        }

        // GET: Training_Program/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training_Program = await _context.Training_Program
                .Include(t => t.trainee)
                .FirstOrDefaultAsync(m => m.id == id);
            if (training_Program == null)
            {
                return NotFound();
            }

            return View(training_Program);
        }
        
        [HttpGet]
        public async Task<IActionResult> BuildingType_selection(TraineeRegister_ViewModel prev_vm)
        {
            TrainingProgram_Selection_ViewModel vm = new TrainingProgram_Selection_ViewModel()
            {
                traineeId = prev_vm.traineeId
            };
            return View("Build_Initial", vm);
        }
        [HttpPost]
        public async Task<IActionResult> BuildingType_selection(TrainingProgram_Selection_ViewModel vm)
        {

            return View("Index");

        }



        [HttpGet]
        public async Task<IActionResult> Categories_builder(Trainee trainee)
        {
            var categories = _context.Category.ToList();
            ProgramBuilder_Categories_ViewModel vm = new ProgramBuilder_Categories_ViewModel()
            {
                categories = categories
            };
            return View("Build_by_category", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Categories_builder(ProgramBuilder_Categories_ViewModel vm)
        {
            List<Muscle> musclesList = GetMuscles_byCategoriesId(vm.selected_categories);
            if (musclesList.Count > 0)
            {
                //TraineeRegister_Muscles_ViewModel vm2 = new TraineeRegister_Muscles_ViewModel(vm.traineeId, last_selected_muscles);
               // return View("Muscles/Selection", vm2);
            }
            return View("Index"); //Need to be Error Handler
        }

        public List<Muscle> GetMuscles_byCategoriesId(List<int> categoriesId)
        {
            List<Muscle> musclesList = new List<Muscle>();
            foreach (int cId in categoriesId)
            {
                var c = _context.Category.FirstOrDefault(c => c.id == cId);
                if (c != null)
                {
                    var temp_muscle = _context.Muscles.
                        Where(m => m.category.id == c.id)
                        .ToList();

                    if (temp_muscle != null)
                        musclesList.AddRange(temp_muscle);
                }
            }
            return musclesList;

        }

        //------------------------------------------------------simple CRUD

        // GET: Training_Program/Create
        public IActionResult Create()
        {
            ViewData["traineeId"] = new SelectList(_context.Trainee, "id", "Discriminator");
            return View();
        }

        // POST: Training_Program/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,traineeId")] Training_Program training_Program)
        {
            if (ModelState.IsValid)
            {
                _context.Add(training_Program);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["traineeId"] = new SelectList(_context.Trainee, "id", "Discriminator", training_Program.traineeId);
            return View(training_Program);
        }

        // GET: Training_Program/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training_Program = await _context.Training_Program.FindAsync(id);
            if (training_Program == null)
            {
                return NotFound();
            }
            ViewData["traineeId"] = new SelectList(_context.Trainee, "id", "Discriminator", training_Program.traineeId);
            return View(training_Program);
        }

        // POST: Training_Program/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,traineeId")] Training_Program training_Program)
        {
            if (id != training_Program.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(training_Program);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Training_ProgramExists(training_Program.id))
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
            ViewData["traineeId"] = new SelectList(_context.Trainee, "id", "Discriminator", training_Program.traineeId);
            return View(training_Program);
        }

        // GET: Training_Program/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training_Program = await _context.Training_Program
                .Include(t => t.trainee)
                .FirstOrDefaultAsync(m => m.id == id);
            if (training_Program == null)
            {
                return NotFound();
            }

            return View(training_Program);
        }

        // POST: Training_Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var training_Program = await _context.Training_Program.FindAsync(id);
            _context.Training_Program.Remove(training_Program);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Training_ProgramExists(int id)
        {
            return _context.Training_Program.Any(e => e.id == id);
        }
    }
}
