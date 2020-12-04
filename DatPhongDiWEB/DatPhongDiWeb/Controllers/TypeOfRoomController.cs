using DatPhongDiWeb.Models;
using DatPhongDiWeb.Models.Service;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Models.TypeOfRoom;
using DatPhongDiWeb.Models.TypeOfRoomService;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"Status/statusView/{(int)Common.Table.TypeOfRoom}");
            return Json(new { data = status });
        }

        [HttpPatch]
        [Route("/typeofroom/Save")]
        public JsonResult Save([FromBody] SaveTypeOfRoom request)
        {
            var result = ApiHelper<SaveTypeOfRoomRes>.HttpPostAsync($"typeofroom/Save", "PATCH", request);
            return Json(new { data = result });
        }

        [HttpPatch]
        [Route("/typeofroom/delete")]
        public JsonResult Deleted([FromBody] ChangeStatusTypeOfRoomReq req)
        {
            var result = ApiHelper<SaveTypeOfRoomRes>.HttpPostAsync($"typeofroom/ChangeStatus", "POST", req);
            return Json(new { data = result });
            
        }

        
        [HttpGet]
        [Route("/typeofroom/GetServiceByRoomtypeId/{id}")]
        public JsonResult GetServiceByRoomtypeId(int id)
        {
            var result = ApiHelper<List<ViewServiceByRoomTypeId>>.HttpGetAsync($"TypeOfRoom/getservicebyroomtypeid/{id}");
            return Json(new { data = result });
        }
    }
}
