using DatPhongDi.Domain.Reponse.Room;
using DatPhongDi.Domain.Request.Room;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface IRoomRepository
    {
        Task<UpdateRoomRes> Update(UpdateRoomReq request);
    }
}
