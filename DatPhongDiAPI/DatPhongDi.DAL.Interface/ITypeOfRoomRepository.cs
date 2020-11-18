using DatPhongDi.Domain.Reponse;
using DatPhongDi.Domain.Request;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ITypeOfRoomRepository
    {
        Task<SaveTypeOfRoomRes> Update(SaveTypeOfRoomReq request);
        Task<TypeOfRoomView> Get(int id);
    }
}
