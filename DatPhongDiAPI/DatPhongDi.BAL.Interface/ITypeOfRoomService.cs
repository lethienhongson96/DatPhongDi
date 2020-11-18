using DatPhongDi.Domain.Request;
using DatPhongDi.Domain.Response;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ITypeOfRoomService
    {
        Task<SaveTypeOfRoomRes> Update(SaveTypeOfRoomReq request);
        Task<TypeOfRoomView> Get(int id);
    }
}
