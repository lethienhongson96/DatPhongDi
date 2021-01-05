using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Booking;
using DatPhongDi.Domain.Response.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public Task<SaveBookingRes> Save(SaveBookingReq request)
        {
            return bookingRepository.Save(request);
        }

        public async Task<BookingView> Get(int Id)
        {
            return await bookingRepository.Get(Id);
        }

        public async Task<IEnumerable<BookingView>> Gets()
        {
            return await bookingRepository.Gets();
        }

        public async Task<SaveBookingRes> ChangeStatusBooking(int Id, int Status)
        {
            return await bookingRepository.ChangeStatusBooking(Id, Status);
        }
    }
}
