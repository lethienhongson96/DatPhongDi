using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public Task<SaveRoomRes> Save(SaveRoomReq request)
        {
            return roomRepository.Save(request);
        }
    }
}
