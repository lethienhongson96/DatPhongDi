using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
using System.Collections.Generic;
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

        public Task<RoomView> Get(int RoomId)
        {
            return roomRepository.Get(RoomId);
        }

        public Task<SaveRoomRes> Save(SaveRoomReq request)
        {
            return roomRepository.Save(request);
        }

        public async Task<IEnumerable<RoomView>> getavailables()
        {
            return await roomRepository.getavailables();
        }

        public async Task<IEnumerable<RoomView>> Gets()
        {
            return await roomRepository.Gets();
        }

        public async Task<SaveRoomRes> ChangeStatus(int id, int status)
        {
            return await roomRepository.ChangeStatus(id, status);
        }
    }
}

