using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Booking;
using DatPhongDi.Domain.Response.Booking;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class BookingRepository : BaseRepository,IBookingRepository
    {
        public async Task<SaveBookingRes> Save(SaveBookingReq saveBookingReq)
        {
            SaveBookingRes Result = new SaveBookingRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", saveBookingReq.Id);
                parameters.Add("@RoomId", saveBookingReq.RoomId);
                parameters.Add("@CustomerId", saveBookingReq.CustomerId);
                parameters.Add("@AmountNight", saveBookingReq.AmountNight);
                parameters.Add("@Checkin", saveBookingReq.Checkin);
                parameters.Add("@CheckOut", saveBookingReq.CheckOut);
                parameters.Add("@Status", saveBookingReq.Status);

                Result = await SqlMapper.QueryFirstOrDefaultAsync<SaveBookingRes>(cnn: connection,
                                                                    sql: "sp_SaveBooking",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return Result;
            }
            catch (Exception)
            {
                return Result;
            }
        }
    }
}
