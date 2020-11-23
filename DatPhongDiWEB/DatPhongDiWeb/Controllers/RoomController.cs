using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
