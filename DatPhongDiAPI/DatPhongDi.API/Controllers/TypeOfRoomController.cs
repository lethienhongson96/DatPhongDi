using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request;
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

        [HttpPost, HttpPatch]
        [Route("api/typeofroom/update")]
        public async Task<OkObjectResult> Update(UpdateTypeOfRoomReq request)
        {
            var result = await typeOfRoomService.Update(request);
            return Ok(result);

        }
    }
}
