using DatPhongDi.BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace DatPhongDi.API.Controllers
{

    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("api/customer/get/{id}")]
        public async Task<OkObjectResult> Get(int id)
        {
            var result = await customerService.Get(id);
            return Ok(result);
        }


        [HttpGet("api/Customer/gets")]
        public async Task<OkObjectResult> Get()
        {
            var courses = await customerService.Gets();
            return Ok(courses);
        }
    }
}
