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


        [HttpPost]
        [Route("/typeOfRoomService/save")]
        public JsonResult Save([FromBody] SaveTypeOfRoomServiceReq request)
        {
            var result = ApiHelper<SaveTypeOfRoomServiceReq>.HttpPostAsync($"TypeOfRoomService/save", "POST", request);
            return Json(new { data = result });
        }

    }
}
