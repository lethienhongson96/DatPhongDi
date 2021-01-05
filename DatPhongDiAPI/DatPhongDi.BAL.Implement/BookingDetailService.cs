using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.BookingDetail;
using DatPhongDi.Domain.Response.BookingDetail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IBookingDetailRepository bookingDetailRepository;

        public BookingDetailService(IBookingDetailRepository bookingDetailRepository)
        {
            this.bookingDetailRepository = bookingDetailRepository;
        }
        public async Task<SaveBookingDetailRes> Save(SaveBookingDetailReq saveBookingDetailReq)
        {
            return await bookingDetailRepository.Save(saveBookingDetailReq);
        }
    }
}
