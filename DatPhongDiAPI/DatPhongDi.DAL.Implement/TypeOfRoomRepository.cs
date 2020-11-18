using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.GetAllTypeOfRoom;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class TypeOfRoomRepository : BaseRepository, ITypeOfRoomRepository
    {
        public async Task<IEnumerable<TypeOfRoomView>> Gets()
        {
            return await SqlMapper.QueryAsync<TypeOfRoomView>(cnn: connection,
                                                        sql: "sp_GetAllTypeOfRoom",
                                                        commandType: CommandType.StoredProcedure);
        }
    }
}
