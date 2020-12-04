using DatPhongDi.Domain.Request.TypeOfRoomService;
using DatPhongDi.Domain.Response.TypeOfRoomService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ITypeOfRoomServiceService
    {
        Task<TypeOfRoomServiceView> Get(int Id);
        Task<IEnumerable<TypeOfRoomServiceView>> Gets();
        Task<SaveTypeOfRoomServiceRes> Save(SaveTypeOfRoomServiceReq createPlanReq);
    }
}
