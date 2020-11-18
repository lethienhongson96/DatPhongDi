using DatPhongDi.Domain.Response.GetAllTypeOfRoom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ITypeOfRoomRepository
    {
        Task<IEnumerable<TypeOfRoomView>> Gets();
    }
}
