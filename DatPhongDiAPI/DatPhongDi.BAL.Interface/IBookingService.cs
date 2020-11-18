using DatPhongDi.Domain.Response.Booking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingView>> Gets(); 
        Task<BookingView> Get(int Id);
        Task<SaveBookingRes> ChangeStatusById(int id,int status);

    }
}
