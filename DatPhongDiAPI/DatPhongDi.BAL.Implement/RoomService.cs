using DatPhongDi.BAL.Interface;
using DatPhongDi.DAL.Interface;
using DatPhongDi.Domain.Response.Room;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatPhongDi.BAL.Implement
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository repository;

        public RoomService(IRoomRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<RoomView>> GetOne()
        {
            return await repository.GetOne();
        }

        public async Task<IEnumerable<RoomView>> Gets()
        {
            return await repository.Gets();
        }
    }
}
