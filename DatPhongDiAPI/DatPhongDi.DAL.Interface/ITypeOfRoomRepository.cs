using DatPhongDi.Domain.Request;
using DatPhongDi.Domain.Response;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ITypeOfRoomRepository
    {
        Task<SaveTypeOfRoomRes> Update(SaveTypeOfRoomReq request);
        Task<TypeOfRoomView> Get(int id);
    }
}
