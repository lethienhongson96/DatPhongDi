using DatPhongDi.Domain.Response.Booking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingView>> Gets();
        Task<BookingView> Get(int Id);
        Task<SaveBookingRes> ChangeStatusById(int id,int status);

    }
}
