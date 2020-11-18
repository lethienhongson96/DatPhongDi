using DatPhongDi.Domain.Request.Booking;
using DatPhongDi.Domain.Response.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IBookingRepository
    {
        Task<SaveBookingRes> Save(SaveBookingReq saveBookingReq);
    }
}
