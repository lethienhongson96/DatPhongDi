using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDiWeb.Models;
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

        [Route("/Booking/delete/{id}")]
        public JsonResult Delete(int id)
        {
            var result = ApiHelper<ResResult>.HttpPostAsync($"booking/changestatusbooking/{id}/4", "POST", new object());
            return Json(new { data = result });
        }

        
    }
}
