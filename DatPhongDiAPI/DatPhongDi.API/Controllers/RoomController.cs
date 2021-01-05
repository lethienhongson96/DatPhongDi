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

        [HttpPost,HttpPatch]
        [Route("api/room/save")]
        public async Task<OkObjectResult> SaveRoom(SaveRoomReq request)
        {
            var result = await roomService.Save(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/room/get/{Id}")]
        public async Task<OkObjectResult> Get(int Id)
        {
            var result = await roomService.Get(Id);
            return Ok(result);
        }

        [HttpGet("api/Room/gets")]
        public async Task<OkObjectResult> Gets()
        {
            var result = await roomService.Gets();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/room/changeStatus/{id}/{status}")]
        public async Task<OkObjectResult> ChangeStatus(int id, int status)
        {
            var result = await roomService.ChangeStatus(id, status);

            return Ok(result);
        }
    }
}

