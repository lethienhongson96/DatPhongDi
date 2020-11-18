using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
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
        public IActionResult Index()
        {
            return View();
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
