using DatPhongDi.Domain.Response.Status;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusView>> GetStatusByTableId(int TableId);
    }
}
