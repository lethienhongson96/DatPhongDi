using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class TypeOfRoomController : ControllerBase
    {
        private readonly ITypeOfRoomService typeOfRoom;

        public TypeOfRoomController(ITypeOfRoomService typeOfRoom )
        {
            this.typeOfRoom = typeOfRoom;
        }
     
        [HttpGet("api/TypeOfRoom/gets")]
        public async Task<OkObjectResult> Get()
        {
            var courses = await typeOfRoom.Gets();
            return Ok(courses);
        }
    }
}
