using DatPhongDi.Domain.Response.GetAllTypeOfRoom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ITypeOfRoomService
    {
        Task<IEnumerable<TypeOfRoomView>> Gets();
    }
}
