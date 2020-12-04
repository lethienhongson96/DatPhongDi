using DatPhongDi.Domain.Request.TypeOfRoomService;
using DatPhongDi.Domain.Response.TypeOfRoomService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ITypeOfRoomServiceRepository
    {
       
        Task<TypeOfRoomServiceView> Get(int Id);
        Task<SaveTypeOfRoomServiceRes> Save(SaveTypeOfRoomServiceReq createPlanReq);
        Task<IEnumerable<TypeOfRoomServiceView>> Gets();
    }
}
