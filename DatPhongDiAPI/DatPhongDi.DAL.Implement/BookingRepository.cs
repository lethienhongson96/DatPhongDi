using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Booking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public async Task<SaveBookingRes> ChangeStatusById(int id,int status)
        {
            var result = new SaveBookingRes()
            {
                Id = 0,
                Message = "Something went wrong, please contact administrator."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@Status", status);

                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveBookingRes>(cnn: connection,
                                                                    sql: "sp_ChangeStatusBookingById",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                return result;
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
                                                      sql: "sp_GetBooking",
                                                      commandType: CommandType.StoredProcedure);
        }
    }
}
