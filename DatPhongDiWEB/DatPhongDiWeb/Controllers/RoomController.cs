using DatPhongDiWeb.Models.Room;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatPhongDiWeb.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/room/gets")]
        public JsonResult Gets()
        {
            var Rooms = ApiHelper<List<RoomView>>.HttpGetAsync("Room/gets");
            return Json(new { data = Rooms });
        }
    }
}
