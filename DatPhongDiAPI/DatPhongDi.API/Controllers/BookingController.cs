using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.Booking;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("api/Booking/gets")]
        public async Task<OkObjectResult> Get()
        {
            var result = await bookingService.Gets();
            return Ok(result);
        }


        [HttpGet("api/Booking/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var result = await bookingService.Get(id);
            return Ok(result);
        }

        [HttpPost, HttpPatch]
        [Route("api/booking/changestatusbooking/{id}/{status}")]
        public async Task<OkObjectResult> ChangeStatusBooking(int id, int status)
        {
            var result = await bookingService.ChangeStatusBooking(id, status);
            return Ok(result);
        }
    }
}
