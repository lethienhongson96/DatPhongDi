using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class TypeOfRoomController : ControllerBase
    {
        private readonly ITypeOfRoomService typeOfRoomService;

        public TypeOfRoomController(ITypeOfRoomService typeOfRoomService)
        {
            this.typeOfRoomService = typeOfRoomService;
        }

        [HttpPost,HttpPatch]
        [Route("api/typeofroom/Save")]
        public async Task<OkObjectResult> SavePlan(SaveTypeOfRoomReq request)
        {
            var result = await typeOfRoomService.Save(request);
            return Ok(result);
        }

        [HttpPatch]
        [Route("api/typeofroom/ChangeStatus")]
        public async Task<OkObjectResult> ChangeStatus(ChangeStatusTypeOfRoomReq request)
        {
            var result = await typeOfRoomService.ChangeStatus(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/typeofroom/get/{Id}")]
        public async Task<OkObjectResult> Get(int Id)
        {
            var result = await typeOfRoomService.Get(Id);
            return Ok(result);
        }

        [HttpGet("api/TypeOfRoom/gets")]
        public async Task<OkObjectResult> Gets()
        {
            var courses = await typeOfRoomService.Gets();
            return Ok(courses);
        }
    }
}
