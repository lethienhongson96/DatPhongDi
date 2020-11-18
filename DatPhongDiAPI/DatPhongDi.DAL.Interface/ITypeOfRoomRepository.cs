using DatPhongDi.Domain.Reponse;
using DatPhongDi.Domain.Request;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ITypeOfRoomRepository
    {
        Task<UpdateTypeOfRoomRes> Update(UpdateTypeOfRoomReq request);
        Task<UpdateTypeOfRoom> Get(int id);
    }
}
