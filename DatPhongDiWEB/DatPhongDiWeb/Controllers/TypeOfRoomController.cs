using DatPhongDiWeb.Models;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Models.TypeOfRoom;
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

        [HttpGet]
        [Route("/TypeOfRoom/DeleteImages/{imageId}")]
        public JsonResult DeleteImages(int imageId)
        {
            var result = ApiHelper<DeleteImageRes>.HttpPostAsync($"image/delete/{imageId}", "POST", new object { });
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
