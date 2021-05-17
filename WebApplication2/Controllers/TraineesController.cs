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
    public class TraineesController : Controller
    {
        private readonly app_context _context;

        public TraineesController(app_context context)
        {
            _context = context;
        }

        // GET: Trainees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trainee.ToListAsync());
        }

        // GET: Trainees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainee
                .FirstOrDefaultAsync(m => m.id == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }


        [HttpGet]
        public async Task<IActionResult> Register(Trainee newTrainee)
        {
            TraineeRegister_Category_ViewModel vm = new TraineeRegister_Category_ViewModel() { 
            traineeId= newTrainee.id};
            return View("SignUpForm", vm);

        }

        [HttpPost]
        public async Task<IActionResult> Register(TraineeRegister_Category_ViewModel vm) {

            Trainee trainee = _context.Trainee.FirstOrDefault(t => t.id==vm.traineeId);
            if (trainee != null) {

                trainee.review=new Review(vm.reviewValue);
                //vm.performance.img_url = vm.img; // Need to add Image upload interface
                //trainee.performances[0] = vm.performance;
                await _context.SaveChangesAsync();

               List<Muscle> muscles = new List<Muscle>();
                foreach (int c in vm.Selected_categorysId)
                {
                    muscles.AddRange(_context.Muscles
                        .Where(m => m.category.ToString().Equals(c))
                        .ToList());
                    //muscles.AddRange(_context.Muscles.Where(m => m.category.ToString() == Enum.GetName(typeof(Category), c)));
                }

                TraineeRegister_Muscles_ViewModel vm2 = new TraineeRegister_Muscles_ViewModel(vm.traineeId,muscles);
                return View("Muscles/Selection",vm2);

            }
            //send to training program builder
            //Need to trhow Exeptions
            return View();
        }

    




        //------------------------------------------------------------------CRUD        

        //public IActionResult Create()
        /*{
           return View();
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
     */
        //public async Task<IActionResult> Create(TraineeCreation_ViewMode vm)
        /* {
             if (ModelState.IsValid)
             {
                 _context.Add(vm.trainee);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }

             return View(vm.trainee);
             */



        // GET: Trainees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainee.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("subscribe_date,id,name,phone,role")] Trainee trainee)
        {
            if (id != trainee.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.id))
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
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainee
                .FirstOrDefaultAsync(m => m.id == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainee = await _context.Trainee.FindAsync(id);
            _context.Trainee.Remove(trainee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
            return _context.Trainee.Any(e => e.id == id);
        }
    }
}
