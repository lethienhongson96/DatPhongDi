using DatPhongDi.Domain.Request.Booking;
using DatPhongDi.Domain.Response.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IBookingService
    {
        Task<SaveBookingRes> Save(SaveBookingReq request);
        Task<IEnumerable<BookingView>> Gets();
        Task<BookingView> Get(int Id);
    }
}
