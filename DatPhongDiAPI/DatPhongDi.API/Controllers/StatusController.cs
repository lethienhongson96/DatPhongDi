using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Implement;
using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
