using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.BookingDetail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class BookingDetailController : ControllerBase
    {
        private readonly IBookingDetailService bookingDetailService;

        public BookingDetailController(IBookingDetailService bookingDetailService)
        {
            this.bookingDetailService = bookingDetailService;
        }

        [HttpPost, HttpPatch]
        [Route("api/bookingdetail/save")]
        public async Task<OkObjectResult> SaveBookingDetail(SaveBookingDetailReq saveBookingDetailReq)
        {
            var result = await bookingDetailService.Save(saveBookingDetailReq);
            return Ok(result);
        }
    }
}
