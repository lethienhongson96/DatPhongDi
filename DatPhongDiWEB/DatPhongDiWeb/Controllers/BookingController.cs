﻿using DatPhongDiWeb.Models;
using DatPhongDiWeb.Models.Booking;
using DatPhongDiWeb.Models.Customer;
using DatPhongDiWeb.Models.Status;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var result = ApiHelper<ResResult>.HttpPostAsync($"booking/changestatusbooking/{id}/3", "POST", new object());
            return Json(new { data = result });
        }

        [HttpPost]
        [Route("/Booking/save")]
        public JsonResult Save([FromBody] SaveBookingReq request)
        {   //Tính số đêm bằng cách lấy ngày checkout trừ ngày checkin
            request.AmountNight = (int)request.CheckOut.Subtract(request.CheckIn).TotalDays;
            var result = ApiHelper<ResResult>.HttpPostAsync($"booking/save", "POST", request);
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/Booking/Status/Gets")]
        public JsonResult GetStatus()
        {
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"Status/statusView/{(int)Common.Table.Booking}");
            return Json(new { data = status });
        }
    }
}
