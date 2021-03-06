﻿using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.DAL.Interface
{
    public interface ITypeOfRoomRepository
    {
        Task<SaveTypeOfRoomRes> Save(SaveTypeOfRoomReq createPlanReq);
        Task<ChangeStatusTypeOfRoomRes> ChangeStatus(ChangeStatusTypeOfRoomReq changeStatusTypeOfRoomReq);
        Task<TypeOfRoomView> Get(int TypeOfRoomId);
        Task<IEnumerable<ViewServiceByRoomTypeId>> GetServiceByRoomTypeId(int TypeOfRoomId);
        Task<IEnumerable<TypeOfRoomView>> Gets();
        Task<IEnumerable<TypeOfRoomView>> CheckAvailable([FromBody] CheckAvailable req);
        Task<RoomTypeDetailView> GetAvailableTypeOfRoom([FromBody] CheckTypeOfRoomAvailableReq req);
    }
}
