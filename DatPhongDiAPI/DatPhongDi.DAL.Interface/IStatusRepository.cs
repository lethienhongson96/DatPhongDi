using DatPhongDi.Domain.Response.Status;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IStatusRepository
    {
        Task<IEnumerable<StatusView>> GetStatus(int tableId);
    }
}
