using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    public class TypeOfRoomController : Controller
    {
        private readonly ITypeOfRoomService typeOfRoom;

        public TypeOfRoomController(ITypeOfRoomService typeOfRoom )
        {
            this.typeOfRoom = typeOfRoom;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("api/TypeOfRoom/gets")]
        public async Task<OkObjectResult> Get()
        {
            var courses = await typeOfRoom.Gets();
            return Ok(courses);
        }
    }
}
