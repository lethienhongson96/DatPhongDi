using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDiWeb.Models.Room;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

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
