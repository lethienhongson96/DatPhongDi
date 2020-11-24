using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("api/Status/GetStatusByTableId/{TableId}")]
        public async Task<OkObjectResult> GetStatusByTableId(int TableId)
        {
            var result = await statusService.GetStatusByTableId(TableId);
            return Ok(result);
        }
    }
}
