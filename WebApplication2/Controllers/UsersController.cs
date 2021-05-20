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
    public class UsersController : Controller
    {
        private readonly app_context _context;


        public UsersController(app_context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Trainee_RegisterProcess([Bind("id,name,phone,role")] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.role == UserRole.Trainee)
                {
                    Trainee Newtrainee = new Trainee()
                    {
                        id = user.id,
                        name = user.name,
                        phone = user.phone,
                        role = user.role,
                        subscribe_date = DateTime.Today.Date

                    };
                    _context.Trainee.Add(Newtrainee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Register", "Trainees", Newtrainee);
                }
                else
                {
                    //Error message 
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(Enum.GetNames(typeof(UserRole)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,phone,role")] User user)
        {
            //The function create Trainee/Coach and upsate the DB
            if (ModelState.IsValid)
            {
                if (user.role == UserRole.Trainee)
                {
                    Trainee Newtrainee = new Trainee()
                    {
                        id = user.id,
                        name = user.name,
                        phone = user.phone,
                        role = user.role,
                        subscribe_date = DateTime.Today.Date

                    };
                    _context.Trainee.Add(Newtrainee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Coach NewCoach = new Coach()
                    {
                        trainings = new List<Training>()
                    };
                    _context.Coach.Add(NewCoach);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View("Index");
        }

        //-------------------------------------------------------------------------------simple CRUD
 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,phone,role")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.id == id);
        }
    }
}
