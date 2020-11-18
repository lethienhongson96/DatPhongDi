using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;

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
       

        [HttpGet("api/Room/gets")]
        public async Task<OkObjectResult> Get()
        {
            var courses = await roomService.Gets();
            return Ok(courses);
        }

        [HttpGet("api/Room/getone")]
        public async Task<OkObjectResult> GetOne()
        {
            var courses = await roomService.GetOne();
            return Ok(courses);
        }

    }
}
