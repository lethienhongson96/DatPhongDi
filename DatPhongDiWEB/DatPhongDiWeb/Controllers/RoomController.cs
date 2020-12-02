using DatPhongDiWeb.Models.Room;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Models.TypeOfRoom;
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
            var Rooms = ApiHelper<List<RoomView>>.HttpGetAsync("room/gets");
            return Json(new { data = Rooms });
        }

       
        [Route("/Room/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = ApiHelper<SaveRoomRes>.HttpPostAsync($"Room/changeStatus/{id}/3", "POST", new object());
            return Json(new { data = result });
        }

        
        [HttpGet]
        [Route("/room/Status/Gets")]
        public JsonResult GetStatus()
        {
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"Status/statusView/{(int)Common.Table.Room}");
            return Json(new { data = status });
        }

        
        [HttpPost]
        [Route("/room/saveroom")]
        public JsonResult SaveRoom([FromBody] SaveRoomReq request)
        {
            var result = ApiHelper<SaveRoomRes>.HttpPostAsync($"room/save", "POST", request);
            return Json(new { data = result });
        }

        
        [HttpGet]
        [Route("/room/GetTypeofrooms")]
        public JsonResult GetTypeOfRoooms()
        {
            var TypeofRoomViews = ApiHelper<List<TypeofRoomView>>.HttpGetAsync("TypeOfRoom/gets");
            return Json(new { data = TypeofRoomViews });
        }
    }
}
