using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class RoomRepository : BaseRepository,IRoomRepository
    {
        public async Task<SaveRoomRes> Save(SaveRoomReq saveRoomReq)
        {
            SaveRoomRes Result = new SaveRoomRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", saveRoomReq.Id);
                parameters.Add("@Name", saveRoomReq.Name);
                parameters.Add("@PricePerNight", saveRoomReq.PricePerNight);
                parameters.Add("@AmountAdult", saveRoomReq.AmountAdult);
                parameters.Add("@AmountChild", saveRoomReq.AmountChild);
                parameters.Add("@Status", saveRoomReq.Status);
                parameters.Add("@TypeOfRoomId", saveRoomReq.TypeOfRoomId);

                Result = await SqlMapper.QueryFirstOrDefaultAsync<SaveRoomRes>(cnn: connection,
                                                                    sql: "sp_SaveRoom",
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
