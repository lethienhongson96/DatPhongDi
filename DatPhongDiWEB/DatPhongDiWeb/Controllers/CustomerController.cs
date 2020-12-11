using DatPhongDiWeb.Models.Customer;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatPhongDiWeb.Controllers
{
    public class CustomerController : Controller
    {
        [HttpPost]
        [Route("customer/payment")]
        public IActionResult Payment(SaveCustomerReq req)
        {
            var status = ApiHelper<SaveCustomerRes>.HttpPostAsync($"customer/save", "POST", req);
            return View(status);
        }
    }
}
