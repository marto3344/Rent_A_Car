using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Web.Data;
using System.Globalization;
namespace Rent_A_Car_Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }
        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,ImageUrl,Seat,Year,Description,Price")] Car car)//Metod za dobacqne na kola
        {
            if (car.Seat < 0 ||car.Seat>7)//Custom validaciq
            {
                ModelState.AddModelError(nameof(car.Seat), $"Seats must be between 1 and 7");
            }
            if(car.Year<1980 ||car.Year >DateTime.Today.Year)
            {
                ModelState.AddModelError(nameof(car.Year), $"Year must be between 1980 and {DateTime.Today.Year}");
            }
            if(car.Price<=0)
            {
                ModelState.AddModelError(nameof(car.Price), $"Car price must be higher than 0");
            }
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("CreateCar");
        }

        public async Task<IActionResult> EditCar(int? id)//Vrushta view kogato e izbrana suotvetnata kola
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar(int id, [Bind("Id,Brand,Model,ImageUrl,Seat,Year,Description,Price,RentStart,RentEnd")] Car car)//Logika za redaktirane kola
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (car.Seat < 0 || car.Seat > 7)//Custom validaciq
            {
                ModelState.AddModelError(nameof(car.Seat), $"Seats must be between 1 and 7");
            }
            if (car.Year < 1980 || car.Year > DateTime.Today.Year)
            {
                ModelState.AddModelError(nameof(car.Year), $"Year must be between 1980 and {DateTime.Today.Year}");
            }
            if (car.Price <= 0)
            {
                ModelState.AddModelError(nameof(car.Price), $"Car price must be higher than 0");
            }
            if (car.RentEnd < car.RentStart)
            {
                ModelState.AddModelError(nameof(car.RentStart),
                                         $"Rent end date can't be before rent start date!Please correct the format!");
            }
            if (car.RentStart.Date < DateTime.Today)
            {
                ModelState.AddModelError(nameof(car.RentStart),
                                         $"Rent cant start at {car.RentStart.ToString("dd/MM/yyyy")}. Today is {DateTime.Today.ToString("dd/MM/yyyy")}. Please enter valid date!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }
        public async Task<IActionResult> CarDetails(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        public async Task<IActionResult> DeleteCar(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set ApplicationDbContext  is null.");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CarExists(int id)
        {
            return _context.Cars.Any(c => c.Id == id);
        }
        private void CarValidation (Car car)
        {
            if (car.Seat < 0)
            {
                ModelState.AddModelError(nameof(Car.Seat), $"Seats must be positive digit");

            }

        }
    }
}
