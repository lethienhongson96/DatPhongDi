using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public async Task<ChangeStatusTypeOfRoomRes> ChangeStatus(ChangeStatusTypeOfRoomReq request)
        {
            return await typeOfRoomRepository.ChangeStatus(request);
        }

        public async Task<IEnumerable<TypeOfRoomView>> CheckAvailable([FromBody] CheckAvailable req)
        {
            return await typeOfRoomRepository.CheckAvailable(req);
        }

        public async Task<TypeOfRoomView> Get(int TypeOfRoomId)
        {
            return await typeOfRoomRepository.Get(TypeOfRoomId);
        }

        public async Task<RoomTypeDetailView> GetAvailableTypeOfRoom([FromBody] CheckTypeOfRoomAvailableReq req)
        {
            return await typeOfRoomRepository.GetAvailableTypeOfRoom(req);
        }

        public async Task<IEnumerable<TypeOfRoomView>> Gets()
        {
            return await typeOfRoomRepository.Gets();
        }

        public async Task<IEnumerable<ViewServiceByRoomTypeId>> GetServiceByRoomTypeId(int TypeOfRoomId)
        {
            return await typeOfRoomRepository.GetServiceByRoomTypeId(TypeOfRoomId);
        }

        public Task<SaveTypeOfRoomRes> Save(SaveTypeOfRoomReq request)
        {
            return typeOfRoomRepository.Save(request);
        }
    }
}
