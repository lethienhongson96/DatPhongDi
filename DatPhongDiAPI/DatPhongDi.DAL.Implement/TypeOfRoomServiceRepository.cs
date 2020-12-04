using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoomService;
using DatPhongDi.Domain.Response.TypeOfRoomService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class TypeOfRoomServiceRepository : BaseRepository, ITypeOfRoomServiceRepository
    {
        public async Task<SaveTypeOfRoomServiceRes> Delete(int id)
        {
            var result = new SaveTypeOfRoomServiceRes()
            {
                Id = 0,
                Message = "Đã xảy ra sự cố, vui lòng liên hệ với quản trị viên."
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                result = await SqlMapper.QueryFirstOrDefaultAsync<SaveTypeOfRoomServiceRes>(cnn: connection,
                                                                    sql: "sp_DeleteTypeOfRoomService",
                                                                    param: parameters,
                                                                    commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {

                return result;
            }
        }

        public async Task<TypeOfRoomServiceView> Get(int Id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", Id);

            return await SqlMapper.QueryFirstOrDefaultAsync<TypeOfRoomServiceView>(cnn: connection,
                                                        sql: "sp_GetsTypeOfRoomService",
                                                        dynamicParameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TypeOfRoomServiceView>> Gets()
        {
            return await SqlMapper.QueryAsync<TypeOfRoomServiceView>(cnn: connection,
                                                  sql: "sp_GetsAllTypeOfRoomService",
                                                  commandType: CommandType.StoredProcedure);
        }

        public async Task<SaveTypeOfRoomServiceRes> Save(SaveTypeOfRoomServiceReq saveType)
        {
            SaveTypeOfRoomServiceRes Result = new SaveTypeOfRoomServiceRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", saveType.Id);
                parameters.Add("@ServiceId", saveType.ServiceId);
                parameters.Add("@TypeOfRoomId", saveType.TypeOfRoomId);
                

                Result = await SqlMapper.QueryFirstOrDefaultAsync<SaveTypeOfRoomServiceRes>(cnn: connection,
                                                                    sql: "sp_SaveTypeOfRoomService",
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
