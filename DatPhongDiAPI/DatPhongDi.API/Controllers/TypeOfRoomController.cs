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

        [HttpPost]
        [Route("api/typeofroom/create")]
        public async Task<OkObjectResult> SavePlan(CreateTypeOfRoomReq request)
        {
            var result = await typeOfRoomService.Create(request);
            return Ok(result);
        }
    }
}
