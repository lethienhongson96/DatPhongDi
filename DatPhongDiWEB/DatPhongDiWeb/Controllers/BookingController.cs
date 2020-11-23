using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDiWeb.Models.Booking;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Booking/gets")]
        public JsonResult Gets()
        {
            var bookings = ApiHelper<List<BookingView>>.HttpGetAsync("Booking/gets");
            return Json(new { data = bookings });
        }
    }
}
