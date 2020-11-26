using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService statusService;

        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }


        [HttpGet("api/Status/statusView/{id}")]
        public async Task<OkObjectResult> GetStatus(int id)
        {
            return Ok(await statusService.GetStatus(id));
        }
    }
}
