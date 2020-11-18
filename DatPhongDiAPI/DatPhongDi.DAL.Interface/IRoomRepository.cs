using DatPhongDi.Domain.Response.Room;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomView>> Gets();
        Task<IEnumerable<RoomView>> GetOne();
    }
}
