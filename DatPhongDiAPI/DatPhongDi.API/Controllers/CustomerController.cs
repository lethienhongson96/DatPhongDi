using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDi.API.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/Customer/gets")]
        public async Task<OkObjectResult> Get()
        {
            var courses = await service.Gets();
            return Ok(courses);
        }
    }
}
