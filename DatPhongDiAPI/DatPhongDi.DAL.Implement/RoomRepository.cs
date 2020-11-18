using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Room;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public async Task<IEnumerable<RoomView>> GetOne()
        {
            return await SqlMapper.QueryAsync<RoomView>(cnn: connection,
                                                        sql: "sp_GetRoom",
                                                        commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RoomView>> Gets()
        {
            return await SqlMapper.QueryAsync<RoomView>(cnn: connection,
                                                       sql: "sp_GetAllRoom",
                                                       commandType: CommandType.StoredProcedure);
        }
    }
}
