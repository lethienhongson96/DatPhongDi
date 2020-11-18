using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<SaveTypeOfRoomRes> Save(SaveTypeOfRoomReq request)
        {
            return typeOfRoomRepository.Save(request);
        }
    }
}
