using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Reponse;
using DatPhongDi.Domain.Request;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class TypeOfRoomService : ITypeOfRoomService
    {
        private readonly ITypeOfRoomRepository typeRoomRepository;  

        public TypeOfRoomService(ITypeOfRoomRepository typeRoomRepository)
        {
            this.typeRoomRepository = typeRoomRepository;
        }

        public Task<UpdateTypeOfRoom> Get(int id)
        {
            return typeRoomRepository.Get(id);
        }

        public Task<UpdateTypeOfRoomRes> Update(UpdateTypeOfRoomReq request)
        {
            return typeRoomRepository.Update(request);
        }
    }
}
