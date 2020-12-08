using DatPhongDiWeb.Models;
using DatPhongDiWeb.Models.Service;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Models.TypeOfRoom;
using DatPhongDiWeb.Models.TypeOfRoomService;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace DatPhongDiWeb.Controllers
{
    public class TypeOfRoomController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public TypeOfRoomController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }
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

        [HttpGet]
        [Route("/TypeOfRoom/getImagesByTypeOfRoomId/{id}")]
        public JsonResult GetImagesByTypeOfRoomId(int id)
        {
            var images = ApiHelper<List<ImageView>>.HttpGetAsync($"image/getImagesByTypeOfRoomId/{id}");
            return Json(new { data = images });
        }

        [HttpPatch]
        [Route("/typeofroom/Save")]
        public JsonResult Save([FromBody] SaveTypeOfRoomReq request)
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
    }
}
