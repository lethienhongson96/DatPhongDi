using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Interface
{
    public interface ITypeOfRoomService
    {
        Task<SaveTypeOfRoomRes> Save(SaveTypeOfRoomReq request);
        Task<ChangeStatusTypeOfRoomRes> ChangeStatus(ChangeStatusTypeOfRoomReq request);
        Task<TypeOfRoomView> Get(int TypeOfRoomId);
        Task<IEnumerable<TypeOfRoomView>> Gets();
        Task<IEnumerable<ViewServiceByRoomTypeId>> GetServiceByRoomTypeId(int TypeOfRoomId);
        Task<IEnumerable<TypeOfRoomView>> CheckAvailable([FromBody] CheckAvailable req);
        Task<RoomTypeDetailView> GetAvailableTypeOfRoom([FromBody] CheckTypeOfRoomAvailableReq req);
    }
}
