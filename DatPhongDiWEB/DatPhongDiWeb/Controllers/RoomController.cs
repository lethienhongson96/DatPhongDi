using DatPhongDiWeb.Models.Room;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatPhongDiWeb.Controllers
{
    public class RoomController : Controller
    {

        //Show all rooms
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


        //Delete room by Id
        [Route("/Room/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = ApiHelper<SaveRoomRes>.HttpPostAsync($"Room/changeStatus/{id}/3", "POST", new object());
            return Json(new { data = result });
        }


        //Get the status of the room
        [HttpGet]
        [Route("/room/Status/Gets")]
        public JsonResult GetStatus()
        {
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"Status/statusView/{(int)Common.Table.Room}");
            return Json(new { data = status });
        }


        //Create and Edit room
        [HttpPost]
        [Route("/room/saveroom")]
        public JsonResult SaveRoom([FromBody] SaveRoomReq request)
        {
            var result = ApiHelper<SaveRoomRes>.HttpPostAsync($"room/save", "POST", request);
            return Json(new { data = result });
        }


        //Get the type off room of the room
        [HttpGet]
        [Route("/room/Typeofroom/GetTypeoffRooom")]
        public JsonResult GetTypeoffRooom()
        {
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"TypeOfRoom/gets");
            return Json(new { data = status });
        }
    }
}
