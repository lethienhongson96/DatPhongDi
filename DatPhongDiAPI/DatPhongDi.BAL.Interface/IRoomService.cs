using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IRoomService
    {
        Task<SaveRoomRes> Update(SaveRoomReq request);
        Task<SaveRoomRes> ChangeStatus(int id, int status);
    }
}
