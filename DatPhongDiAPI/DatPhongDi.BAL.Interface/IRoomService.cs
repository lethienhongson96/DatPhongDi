using DatPhongDi.Domain.Response.Room;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomView>> Gets();
        Task<IEnumerable<RoomView>> GetOne();
    }
}
