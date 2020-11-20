using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using DatPhongDi.Domain.Request.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }
        [HttpPost]
        [Route("api/service/save")]
        public async Task<OkObjectResult> Save(SaveServiceReq req)
        {
            var result = await serviceService.Save(req);
            return Ok(result);
        }
        [HttpGet]
        [Route("api/service/gets")]
        public async Task<OkObjectResult> Gets()
        {
            var result = await serviceService.Gets();
            return Ok(result);
        }
        [HttpGet]
        [Route("api/service/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var result = await serviceService.Get(id);
            return Ok(result);
        }
        [HttpPatch]
        [Route("api/service/changeStatus")]
        public async Task<OkObjectResult> ChangeStatusService(ChangeStatusServiceReq req)
        {
            var result = await serviceService.ChangeStatusService(req);
            return Ok(result);
        }
    }
}
