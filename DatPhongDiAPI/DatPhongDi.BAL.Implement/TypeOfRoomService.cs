using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request;
using DatPhongDi.Domain.Response;
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

        public Task<TypeOfRoomView> Get(int id)
        {
            return typeRoomRepository.Get(id);
        }

        public Task<SaveTypeOfRoomRes> Update(SaveTypeOfRoomReq request)
        {
            return typeRoomRepository.Update(request);
        }
    }
}
