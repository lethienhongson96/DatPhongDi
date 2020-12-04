using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.TypeOfRoomService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatPhongDi.API.Controllers
{
    public class TypeOfRoomServiceController : Controller
    {
        private readonly ITypeOfRoomServiceService typeOfRoomServiceService;

        public TypeOfRoomServiceController(ITypeOfRoomServiceService typeOfRoomServiceService)
        {
            this.typeOfRoomServiceService = typeOfRoomServiceService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, HttpPatch]
        [Route("api/TypeOfRoomService/save")]
        public async Task<OkObjectResult> Save([FromBody] SaveTypeOfRoomServiceReq saveTypeOfRoomServiceReq)
        {
            var result = await typeOfRoomServiceService.Save(saveTypeOfRoomServiceReq);
            return Ok(result);
        }

        [HttpGet("api/TypeOfRoomService/get{Id}")]
        public async Task<OkObjectResult> Get(int Id)                                                                                                  
        {
            var result = await typeOfRoomServiceService.Get(Id);
            return Ok(result);
        }

        [HttpGet("api/TypeOfRoomService/gets")]
        public async Task<OkObjectResult> Gets()
        {
            var result = await typeOfRoomServiceService.Gets();
            return Ok(result);
        }

        [HttpPatch]
        [Route("api/TypeOfRoomService/delete/{id}")]
        public async Task<OkObjectResult> Delete(int id)
        {
            var result = await typeOfRoomServiceService.Delete(id);
            return Ok(result);
        }


    }
}
