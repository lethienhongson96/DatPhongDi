using Dapper;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Status;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Implement
{
    public class StatusRepository : BaseRepository, IStatusRepository
    {
        public async Task<IEnumerable<StatusView>> GetStatus(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@TableId", Id);
            return await SqlMapper.QueryAsync<StatusView>(cnn: connection,
                                                        sql: "sp_GetStatus",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
        }
    }
}
