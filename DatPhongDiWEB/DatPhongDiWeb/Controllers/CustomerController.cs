using DatPhongDiWeb.Models.Customer;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class CustomerController : Controller
    {
        [HttpPost]
        [Route("customer/payment")]
        public JsonResult Payment([FromBody] SaveCustomerReq req)
        {
            var result = new SaveCustomerRes();
            if (ModelState.IsValid)
            {
                result = ApiHelper<SaveCustomerRes>.HttpPostAsync($"customer/save", "POST", req);
                return Json(new { data = result });
            }
            return Json(0);
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
