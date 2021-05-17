using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalTrainerApp.Data;
using PersonalTrainerApp.Models;

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
