using DatPhongDi.Domain.Request.Booking;
using DatPhongDi.Domain.Response.Booking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IBookingRepository
    {
        Task<SaveBookingRes> Save(SaveBookingReq saveBookingReq);
        Task<IEnumerable<BookingView>> Gets();
        Task<BookingView> Get(int Id);
    }
}
