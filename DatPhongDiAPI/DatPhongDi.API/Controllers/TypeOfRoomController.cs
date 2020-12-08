using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoom;
using DatPhongDi.Domain.Response.TypeOfRoom;
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
        public async Task<OkObjectResult> SaveTypeOfRoom(SaveTypeOfRoomReq request)
        {
            var result = await typeOfRoomService.Save(request);
            return Ok(result);
        }

        [HttpPatch,HttpPost]
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
            var result = await typeOfRoomService.Gets();
            return Ok(result);
        }

        [HttpGet("api/TypeOfRoom/getservicebyroomtypeid/{TypeOfRoomId}")]
        public async Task<OkObjectResult> GetServiceByRoomtypeId(int TypeOfRoomId)
        {
            var result = await typeOfRoomService.GetServiceByRoomTypeId(TypeOfRoomId);
            return Ok(result);
        }
        [HttpPost]
        [Route("api/TypeofRoom/CheckAvailable")]
        public async Task<OkObjectResult> CheckAvailable([FromBody] CheckAvailable req)
        {
            var result = await typeOfRoomService.CheckAvailable(req);
            return Ok(result);
        }
    }
}
