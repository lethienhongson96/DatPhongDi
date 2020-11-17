using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class TypeOfRoomRepository : BaseRepository,ITypeOfRoomRepository
    {
        public async Task<CreateTypeOfRoomRes> Create(CreateTypeOfRoomReq createTypeOfRoomReq)
        {
            CreateTypeOfRoomRes Result = new CreateTypeOfRoomRes();

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", createTypeOfRoomReq.Name);
                parameters.Add("@Status", createTypeOfRoomReq.Status);

                Result = await SqlMapper.QueryFirstOrDefaultAsync<CreateTypeOfRoomRes>(cnn: connection,
                                                                    sql: "sp_CreateTypeOfRoom",
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
