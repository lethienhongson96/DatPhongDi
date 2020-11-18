using DatPhongDi.Domain.Reponse.Room;
using DatPhongDi.Domain.Request.Room;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface IRoomService
    {
        Task<UpdateRoomRes> Update(UpdateRoomReq request);
        Task<UpdateRoomRes> ChangeStatus(int id, int status);
    }
}
