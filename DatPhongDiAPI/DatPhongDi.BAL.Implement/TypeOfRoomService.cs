using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.GetAllTypeOfRoom;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class TypeOfRoomService : ITypeOfRoomService
    {
        private readonly ITypeOfRoomRepository typeOfRoom;

        public TypeOfRoomService(ITypeOfRoomRepository typeOfRoom)
        {
            this.typeOfRoom = typeOfRoom;
        }
        public async Task<IEnumerable<TypeOfRoomView>> Gets()
        {
            return await typeOfRoom.Gets();
        }
    }
}
