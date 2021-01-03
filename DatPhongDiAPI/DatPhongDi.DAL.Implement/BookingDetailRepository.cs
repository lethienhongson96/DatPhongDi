using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.BookingDetail;
using DatPhongDi.Domain.Response.BookingDetail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class BookingDetailRepository : BaseRepository,IBookingDetailRepository
    {
        public async Task<SaveBookingDetailRes> Save(SaveBookingDetailReq saveBookingDetailReq)
        {
            SaveBookingDetailRes Result = new SaveBookingDetailRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", saveBookingDetailReq.Id);
                parameters.Add("@BookingId", saveBookingDetailReq.BookingId);
                parameters.Add("@RoomId", saveBookingDetailReq.RoomId);
                parameters.Add("@Price", saveBookingDetailReq.Price);

                Result = await SqlMapper.QueryFirstOrDefaultAsync<SaveBookingDetailRes>(cnn: connection,
                                                                    sql: "sp_SaveBookingDetail",
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
