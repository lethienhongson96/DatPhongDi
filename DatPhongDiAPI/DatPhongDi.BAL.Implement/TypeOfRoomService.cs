using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.GetAllTypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using System;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class TypeOfRoomService : ITypeOfRoomService
    {
        private readonly ITypeOfRoomRepository typeOfRoomRepository;

        public TypeOfRoomService(ITypeOfRoomRepository typeOfRoomRepository)
        {
            this.typeOfRoomRepository = typeOfRoomRepository;
        }

        public Task<ChangeStatusTypeOfRoomRes> ChangeStatus(ChangeStatusTypeOfRoomReq request)
        {
            return typeOfRoomRepository.ChangeStatus(request);
        }

        public Task<TypeOfRoomView> Get(int TypeOfRoomId)
        {
            return typeOfRoomRepository.Get(TypeOfRoomId);
        }

        public async Task<TypeOfRoomView> Gets()
        {
            return await typeOfRoomRepository.Gets();
        }

        public Task<SaveTypeOfRoomRes> Save(SaveTypeOfRoomReq request)
        {
            return typeOfRoomRepository.Save(request);
        }
    }
}
