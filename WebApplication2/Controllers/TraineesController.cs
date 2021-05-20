using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalTrainerApp.Data;
using PersonalTrainerApp.Models;
using Microsoft.AspNetCore.Hosting;


using PersonalTrainerApp.ViewModels;
using Microsoft.AspNetCore.Http;

namespace PersonalTrainerApp.Controllers
{
    public class TraineesController : Controller
    {
        private readonly app_context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TraineesController(app_context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
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
            TraineeRegister_ViewModel vm = new TraineeRegister_ViewModel() {
                traineeId = newTrainee.id, };
            return View("Adjustments", vm);

        }
        [HttpPost]
        public async Task<IActionResult> Register(TraineeRegister_ViewModel vm) {

            Trainee trainee = _context.Trainee.FirstOrDefault(t => t.id == vm.traineeId);

            if (trainee != null) {

                //Create Trainee.Review property
                trainee.review = new Review(vm.reviewTrainee, vm.reviewCoach);

                //Create Trainee.Preformance property
                string ImageName = getImage_Name(vm.img_file, trainee.name);
                if (ImageName != null)
                {
                    string path = getImage_Path(ImageName);
                    trainee.performances.Add(new Performance
                    {
                        traineeId = trainee.id,
                        img_name = ImageName,
                        img_url = path

                    });
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await vm.img_file.CopyToAsync(fileStream);
                    }
                    await _context.SaveChangesAsync();
                }
            }
     
            return View("Index"); 
        }

        public async Task<IActionResult> Build_Program(TraineeRegister_ViewModel vm)
        {

            Trainee trainee = _context.Trainee.FirstOrDefault(t => t.id == vm.traineeId);

            if (trainee != null)
            {

                //Create Trainee.Review property
                trainee.review = new Review(vm.reviewTrainee, vm.reviewCoach);

                //Create Trainee.Preformance property
                string ImageName = getImage_Name(vm.img_file, trainee.name);
                if (ImageName != null)
                {
                    string path = getImage_Path(ImageName);
                    trainee.performances.Add(new Performance
                    {
                        traineeId = trainee.id,
                        img_name = ImageName,
                        img_url = path

                    });
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await vm.img_file.CopyToAsync(fileStream);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("BuildingType_selection", "Training_Program", vm);

        }

        private string getImage_Name(IFormFile img, string traineeName)
        {
            if (img != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(img.FileName);
                string extension = Path.GetExtension(img.FileName);
                string uniqFileName = fileName + "_" + traineeName + "_" + DateTime.Now.ToString("YYMM") + extension;
                return uniqFileName;
            }
            return null;
            
        }

        private string getImage_Path(string fileName)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string path = Path.Combine(wwwRootPath + "/trainee_prerformance_images/", fileName); 
            return path;
        }


        //------------------------------------------------------------------CRUD        
        [HttpGet]

        public IActionResult Create()
        {
           return View();
       }

       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainee trainee)
        {

            return View("Index");
        }
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
