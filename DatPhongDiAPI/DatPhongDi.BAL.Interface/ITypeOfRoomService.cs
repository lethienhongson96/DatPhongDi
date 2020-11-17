using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ITypeOfRoomService
    {
        Task<CreateTypeOfRoomRes> Create(CreateTypeOfRoomReq request);
    }
}
