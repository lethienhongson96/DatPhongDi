using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.Booking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost, HttpPatch]
        [Route("api/booking/save")]
        public async Task<OkObjectResult> SaveBooking(SaveBookingReq request)
        {
            var result = await bookingService.Save(request);
            return Ok(result);
        }
    }
}
