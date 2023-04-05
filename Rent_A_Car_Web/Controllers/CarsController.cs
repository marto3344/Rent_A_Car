using Microsoft.AspNetCore.Mvc;

namespace Rent_A_Car_Web.Views.Cars
{
    public class CarController : Controller
    {
        public IActionResult ViewCars()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
