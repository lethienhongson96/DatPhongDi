using DatPhongDi.Domain.Reponse;
using DatPhongDi.Domain.Request;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ITypeOfRoomService
    {
        Task<SaveTypeOfRoomRes> Update(SaveTypeOfRoomReq request);
        Task<TypeOfRoomView> Get(int id);
    }
}
