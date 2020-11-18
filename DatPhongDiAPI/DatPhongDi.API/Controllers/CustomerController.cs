using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet("api/Customer/gets")]
        public async Task<OkObjectResult> Get()
        {
            var courses = await service.Gets();
            return Ok(courses);
        }
    }
}
