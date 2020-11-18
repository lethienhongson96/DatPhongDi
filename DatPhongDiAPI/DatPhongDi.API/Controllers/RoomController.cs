using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.Room;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpPost, HttpPatch]
        [Route("api/room/update")]
        public async Task<OkObjectResult> Update(SaveRoomReq request)
        {
            var result = await roomService.Update(request);
            return Ok(result);
        }

        [HttpPatch]
        [Route("api/room/changeStatus/{id}/{status}")]
        public async Task<OkObjectResult> ChangeStatus(int id, int status)
        {
            var result = await roomService.ChangeStatus(id, status);

            return Ok(result);
        }

    }
}
