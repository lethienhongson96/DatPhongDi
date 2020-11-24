using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Status;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class StatusRepository : BaseRepository, IStatusRepository
    {
        public async Task<IEnumerable<StatusView>> GetStatus(int tableId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TableId", tableId);
            return await SqlMapper.QueryAsync<StatusView>(cnn: connection,
                                                          sql: "sp_GetStatus",
                                                          param: parameters,
                                                          commandType: CommandType.StoredProcedure);
        }
    }
}
