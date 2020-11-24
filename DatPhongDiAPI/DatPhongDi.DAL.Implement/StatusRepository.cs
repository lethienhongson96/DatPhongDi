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
    public class StatusRepository : BaseRepository,IStatusRepository
    {
        public async Task<IEnumerable<StatusView>> GetStatusByTableId(int TableId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@TableId", TableId);

            return await SqlMapper.QueryAsync<StatusView>(cnn: connection,
                                                     sql: "sp_GetStatusByTableId",
                                                     dynamicParameters,
                                                     commandType: CommandType.StoredProcedure);
        }
    }
}
