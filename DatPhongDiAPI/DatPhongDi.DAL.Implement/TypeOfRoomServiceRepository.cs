using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoomService;
using DatPhongDi.Domain.Response.TypeOfRoomService;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class TypeOfRoomServiceRepository : BaseRepository, ITypeOfRoomServiceRepository
    {
        public async Task<TypeOfRoomServiceView> Get(int Id)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", Id);

            return await SqlMapper.QueryFirstOrDefaultAsync<TypeOfRoomServiceView>(cnn: connection,
                                                        sql: "sp_GetsTypeOfRoomService",
                                                        dynamicParameters,
                                                        commandType: CommandType.StoredProcedure);
        }

        

        public async Task<SaveTypeOfRoomServiceRes> Save(SaveTypeOfRoomServiceReq createPlanReq)
        {
            SaveTypeOfRoomServiceRes Result = new SaveTypeOfRoomServiceRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", createPlanReq.Id);
                parameters.Add("@ServiceId", createPlanReq.ServiceId);
                parameters.Add("@TypeOfRoomId", createPlanReq.TypeOfRoomId);
                

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
