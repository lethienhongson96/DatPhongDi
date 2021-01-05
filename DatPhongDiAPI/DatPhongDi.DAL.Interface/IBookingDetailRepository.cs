using DatPhongDi.Domain.Request.BookingDetail;
using DatPhongDi.Domain.Response.BookingDetail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IBookingDetailRepository
    {
        Task<SaveBookingDetailRes> Save(SaveBookingDetailReq saveBookingDetailReq);
    }
}
