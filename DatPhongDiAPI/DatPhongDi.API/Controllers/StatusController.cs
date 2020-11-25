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
        [HttpGet]
        [Route("api/status/{tableId}")]
        public async Task<OkObjectResult> Gets(int tableId)
        {
            var result = await statusService.GetStatus(tableId);
            return Ok(result);
        }
    }
}
