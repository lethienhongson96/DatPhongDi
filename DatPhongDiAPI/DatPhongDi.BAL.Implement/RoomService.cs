using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Reponse.Room;
using DatPhongDi.Domain.Request.Room;
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

        public async Task<UpdateRoomRes> ChangeStatus(int id, int status)
        {
            return await roomRepository.ChangeStatus(id,status);
        }

        public async Task<UpdateRoomRes> Update(UpdateRoomReq request)
        {
            return await roomRepository.Update(request);
        }
    }
}
