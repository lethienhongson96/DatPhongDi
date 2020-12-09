using DatPhongDiWeb.Models;
using DatPhongDiWeb.Models.Service;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Models.TypeOfRoom;
using DatPhongDiWeb.Models.TypeOfRoomService;
using DatPhongDiWeb.Ultilities;
using DatPhongDiWeb.Views.TypeOfRoom;
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

        [HttpGet]
        public IActionResult RoomTypeDetail(int Id, DateTime CheckIn, DateTime CheckOut)
        {
            CheckTypeOfRoomAvailable checkTypeOfRoomAvailable = new CheckTypeOfRoomAvailable() { Id = Id, CheckIn = CheckIn, CheckOut = CheckOut};
            var result = ApiHelper<RoomTypeDetailView>.HttpPostAsync($"TypeOfRoom/GetAvailableTypeOfRoom", "POST", checkTypeOfRoomAvailable);
            return View(result);
        }

        [HttpPost]
        public IActionResult CheckAvailable(CheckAvailable req)
        {
            ViewBag.CheckIn = req.CheckIn;
            ViewBag.CheckOut = req.CheckOut;
            var data = ApiHelper<List<TypeofRoomView>>.HttpPostAsync($"TypeofRoom/CheckAvailable", "POST", req);
            return View(data);
        }

        [HttpGet]
        [Route("/typeofroom/GetServiceByRoomtypeId/{id}")]
        public JsonResult GetServiceByRoomtypeId(int id)
        {
            var result = ApiHelper<List<ViewServiceByRoomTypeId>>.HttpGetAsync($"TypeOfRoom/getservicebyroomtypeid/{id}");
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/TypeOfRoom/DeleteImages/{imageId}/{imgpath}")]
        public JsonResult DeleteImages(int imageId, string imgpath)
        {
            var result = ApiHelper<DeleteImageRes>.HttpPostAsync($"image/delete/{imageId}", "POST", new object { });
            if (result.ImageId > 0)
            {
                string DelPath = Path.Combine(_hostEnvironment.WebRootPath, "images", imgpath);
                System.IO.File.Delete(DelPath);
            }
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/typeofroom/UploadImages")]
        public JsonResult UploadImages(List<IFormFile> Files, int TypeOfRoomId)
        {
            int CountUploadSuccess = 0;
            foreach (var item in Files)
            {
                string pathstr = UploadedFile(item);
                ImageView imageView = new ImageView()
                {
                    ImageId = 0,
                    ImagePath = pathstr,
                    TypeOfRoomId = TypeOfRoomId
                };
                SaveImageRes result = ApiHelper<SaveImageRes>.HttpPostAsync($"image/save", "POST", imageView);

                if (result.ImageId > 0)
                    CountUploadSuccess++;
            }
            return Json(new { data = CountUploadSuccess });
        }

        private string UploadedFile(IFormFile iformfile_path)
        {
            string uniqueFileName = null;

            if (iformfile_path != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + iformfile_path.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                iformfile_path.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}
