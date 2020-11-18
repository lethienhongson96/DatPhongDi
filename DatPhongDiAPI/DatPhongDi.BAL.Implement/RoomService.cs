using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Request.Room;
using DatPhongDi.Domain.Response.Room;
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

        public async Task<SaveRoomRes> ChangeStatus(int id, int status)
        {
            return await roomRepository.ChangeStatus(id,status);
        }

        public async Task<SaveRoomRes> Update(SaveRoomReq request)
        {
            return await roomRepository.Update(request);
        }
    }
}
