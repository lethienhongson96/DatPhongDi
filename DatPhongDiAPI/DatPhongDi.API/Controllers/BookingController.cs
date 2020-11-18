using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService service;

        public BookingController(IBookingService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/Booking/gets")]
        public async Task<OkObjectResult> Get()
        {
            var courses = await service.Gets();
            return Ok(courses);
        }



        [HttpGet("api/Booking/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var course = await service.Get(id);
            return Ok(course);
        }
        [HttpPatch]
        [Route("api/Booking/ChangeStatusById/{id}/{status}")]
        public async Task<OkObjectResult> ChangeStatusById(int id,int status)
        {
            var result = await service.ChangeStatusById(id, status);
            return Ok(result);
        }

    }
}
