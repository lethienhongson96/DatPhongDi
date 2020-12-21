using DatPhongDiWeb.Models.Customer;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class CustomerController : Controller
    {
        [HttpPost]
        [Route("customer/payment")]
        public IActionResult Payment(SaveCustomerReq req)
        {
            var result = new SaveCustomerRes();
            if (ModelState.IsValid)
            {
                result = ApiHelper<SaveCustomerRes>.HttpPostAsync($"customer/save", "POST", req);
                if (result.Id != 0)
                {
                    TempData["success"] = result.Message;
                }
                else
                {
                    TempData["error"] = result.Message;
                }
            }
            
            return View(req);
        }

        [HttpGet]
        public IActionResult Payment()
        {
            TempData["success"] = null;
            TempData["error"] = null;
            return View();
        }
    }
}
