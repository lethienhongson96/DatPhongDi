using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Booking;
using DatPhongDi.Domain.Response.Booking;
using System;
using System.Collections.Generic;
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

        public async Task<BookingView> Get(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            return await SqlMapper.QueryFirstOrDefaultAsync<BookingView>(cnn: connection,
                                                        sql: "sp_GetBookingById",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BookingView>> Gets()
        {
            return await SqlMapper.QueryAsync<BookingView>(cnn: connection,
                                                      sql: "sp_GetBookings",
                                                      commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveBookingRes> ChangeStatusBooking(int Id, int Status)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            parameters.Add("@Status", Status);

            return await SqlMapper.QueryFirstOrDefaultAsync<SaveBookingRes>(cnn: connection,
                                                      sql: "sp_ChangeStatusBooking",
                                                      param: parameters,
                                                      commandType: CommandType.StoredProcedure);
        }
    }
}
