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
        public Task<CreateTypeOfRoomRes> Create(CreateTypeOfRoomReq request)
        {
            return typeOfRoomRepository.Create(request);
        }
    }
}
