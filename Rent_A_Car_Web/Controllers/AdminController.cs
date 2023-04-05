using Microsoft.AspNetCore.Mvc;

namespace Rent_A_Car_Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
