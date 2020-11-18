using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpPost,HttpPatch]
        [Route("api/room/save")]
        public async Task<OkObjectResult> SaveRoom(SaveRoomReq request)
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/Room/gets")]
        public async Task<OkObjectResult> Get()
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
    }
}
