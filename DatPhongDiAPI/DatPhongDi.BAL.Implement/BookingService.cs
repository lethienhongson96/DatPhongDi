using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Booking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository repository;

        public BookingService(IBookingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SaveBookingRes> ChangeStatusById(int id,int status)
        {
            return await repository.ChangeStatusById(id, status);
        }

        public async Task<BookingView> Get(int Id)
        {
            return await repository.Get(Id);
        }

        public async Task<IEnumerable<BookingView>> Gets()
        {
            return await repository.Gets();
        }
    }
}
