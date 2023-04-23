using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Web.Data;

namespace Rent_A_Car_Web.Views.Cars
{
    [BindProperties]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public CarsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
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
        public async Task<IActionResult> RentCar(int? id)//Vrushta view kogato e izbrana suotvetnata kola
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
        public async Task<IActionResult> RentCar(int id, [Bind("Id,Brand,Model,ImageUrl,Seat,Year,Description,Price")] Car? car)//Logika za naemane na kola
        {
            var user = _userManager.FindByEmailAsync(User.Identity?.Name).Result;
            car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            if (this.RentStart.Date < DateTime.Today)
            {
                ModelState.AddModelError(nameof(car.RentStart),
                                         $"Rent cant start at {this.RentStart.ToString("dd/MM/yyyy")}. Today is {DateTime.Today.ToString("dd/MM/yyyy")}. Please enter valid date!");
                return View("CarDetails", car);
            }
            if (this.RentEnd < this.RentStart)
            {
                ModelState.AddModelError(nameof(car.RentStart),
                                         $"Rent end date can't be before rent start date!Please correct the format!");

                return View("CarDetails", car);
            }

            car.Availabilyty = false;
            car.RentStart = this.RentStart;
            car.RentEnd = this.RentEnd;
            car.RentedByUserId = user.Id;
            _context.Update(car);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Profile");


        }
        private bool CarExists(int id)//Proverka dali sushtestvuva tazi kola v sistemat
        {
            return _context.Cars.Any(c => c.Id == id);
        }


    }
}
