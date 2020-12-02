using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class RoomRepository : BaseRepository,IRoomRepository
    {
        public async Task<RoomView> Get(int RoomId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", RoomId);

            return await SqlMapper.QueryFirstOrDefaultAsync<RoomView>(cnn: connection,
                                                        sql: "sp_GetRoom",
                                                        dynamicParameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RoomView>> Getavailables()
        {
            return await SqlMapper.QueryAsync<RoomView>(cnn: connection,
                                                        sql: "sp_GetAvailableRoom",
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RoomView>> Gets()
        {
            return await SqlMapper.QueryAsync<RoomView>(cnn: connection,
                                                       sql: "sp_GetAllRoom",
                                                       commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveRoomRes> Save(SaveRoomReq saveRoomReq)
        {
            SaveRoomRes Result = new SaveRoomRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", saveRoomReq.Id);
                parameters.Add("@Name", saveRoomReq.Name);              
                parameters.Add("@Status", saveRoomReq.Status);
                parameters.Add("@TypeOfRoomId", saveRoomReq.TypeOfRoomId);
                parameters.Add("@Description", saveRoomReq.Description);
                parameters.Add("@Size", saveRoomReq.Size);

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

        public async Task<SaveRoomRes> ChangeStatus(int id, int status)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@Status", status);
            return await SqlMapper.QueryFirstOrDefaultAsync<SaveRoomRes>(cnn: connection,
                                                        sql: "sp_ChangeStatusRoom",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }
    }
}


