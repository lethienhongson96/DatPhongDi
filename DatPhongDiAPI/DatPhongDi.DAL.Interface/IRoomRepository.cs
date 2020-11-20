using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IRoomRepository
    {
        Task<SaveRoomRes> Save(SaveRoomReq saveRoomReq);
        Task<RoomView> Get(int RoomId);
        Task<IEnumerable<RoomView>> Gets();
        Task<IEnumerable<RoomView>> Getavailables();
        Task<SaveRoomRes> ChangeStatus(int id, int status);
    }
}

