using DatPhongDiWeb.Models;
using DatPhongDiWeb.Models.Service;
using DatPhongDiWeb.Models.TypeOfRoom;
using DatPhongDiWeb.Models.TypeOfRoomService;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatPhongDiWeb.Controllers
{
    public class TypeOfRoomServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/TypeOfRoomService/gets")]
        public JsonResult Gets()
        {
            var bookings = ApiHelper<List<TypeOfRoomServiceView>>.HttpGetAsync("TypeOfRoomService/gets");
            return Json(new { data = bookings });
        }

        [HttpGet]
        [Route("/typeOfRoomService/GetTypeofrooms")]
        public JsonResult GetTypeOfRoooms()
        {
            var TypeofRoomViews = ApiHelper<List<TypeofRoomView>>.HttpGetAsync("TypeOfRoom/gets");
            return Json(new { data = TypeofRoomViews });
        }


        [HttpGet]
        [Route("/typeOfRoomService/GetsService")]
        public JsonResult GetsService()
        {
            var modules = ApiHelper<List<ServiceView>>.HttpGetAsync("service/gets");
            return Json(new { data = modules });
        }

        [HttpPost]
        [Route("/typeOfRoomService/save")]
        public JsonResult Save(int TypeOfRoomId,int[] ServiceId)
        {
            var result = new ResResult();
            for (int i = 0; i < ServiceId.Length; i++)
            {
                SaveTypeOfRoomServiceReq saveTypeOfRoomServiceReq = new SaveTypeOfRoomServiceReq()
                {
                    ServiceId = ServiceId[i],
                    TypeOfRoomId = TypeOfRoomId,
                    Id = 0
                };
                result = ApiHelper<ResResult>.HttpPostAsync($"typeOfRoomService/save", "POST", saveTypeOfRoomServiceReq);
                if (result.Id < 0)
                    return Json(new { data = result });
            }

            return Json(new { data = result });
        }

        [Route("/typeOfRoomService/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = ApiHelper<ResResult>.HttpPatchAsync($"typeOfRoomService/delete/{id}");
            return Json(new { data = result });
        }

    }
}
