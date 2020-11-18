using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Reponse.Room;
using DatPhongDi.Domain.Request.Room;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public async Task<UpdateRoomRes> ChangeStatus(int id, int status)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@Status", status);
            return await SqlMapper.QueryFirstOrDefaultAsync<UpdateRoomRes>(cnn: connection,
                                                        sql: "sp_ChangeStatusRoom",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<UpdateRoomRes> Update(UpdateRoomReq request)
        {
            var result = new UpdateRoomRes()
            {
                Id = 0,
                Message = "Đã xảy ra lỗi, vui lòng thử lại sau !!!"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);
                parameters.Add("@Name", request.Name);
                parameters.Add("@PricePerNight", request.PricePerNight);
                parameters.Add("@AmountAdult", request.AmountAdult);
                parameters.Add("@AmountChild", request.AmountChild);
                parameters.Add("@Status", request.Status);
                parameters.Add("@TypeOfRoomId", request.TypeOfRoomId);

                result = await SqlMapper.QueryFirstOrDefaultAsync<UpdateRoomRes>(cnn: connection,
                                                                    sql: "sp_UpdateRoom",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
    }
}

