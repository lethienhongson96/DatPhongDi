using DatPhongDi.Domain.Request.BookingDetail;
using DatPhongDi.Domain.Response.BookingDetail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IBookingDetailService
    {
        Task<SaveBookingDetailRes> Save(SaveBookingDetailReq saveBookingDetailReq);
    }
}
