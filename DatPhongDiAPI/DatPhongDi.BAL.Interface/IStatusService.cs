using DatPhongDi.Domain.Response.Status;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IStatusService
    {

        Task<IEnumerable<StatusView>> GetStatus(int tableId);

    }
}
