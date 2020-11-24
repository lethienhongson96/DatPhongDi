using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Models.TypeOfRoom;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class TypeOfRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/TypeOfRoom/gets")]
        public JsonResult Gets()
        {
            var typeofRoom = ApiHelper<List<TypeofRoomView>>.HttpGetAsync("TypeOfRoom/gets");
            return Json(new { data = typeofRoom });
        }

        [HttpGet]
        [Route("/TypeOfRoom/status/gets")]
        public JsonResult GetStatus()
        {
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"status/{(int)Common.Table.TypeOfRoom}");
            return Json(new { data = status });
        }
    }
}
