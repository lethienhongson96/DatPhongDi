using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }
    }
}
