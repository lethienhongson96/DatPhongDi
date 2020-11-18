using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ITypeOfRoomService
    {
        Task<SaveTypeOfRoomRes> Save(SaveTypeOfRoomReq request);
        Task<ChangeStatusTypeOfRoomRes> ChangeStatus(ChangeStatusTypeOfRoomReq request);
        Task<TypeOfRoomView> Get(int TypeOfRoomId);
    }
}
