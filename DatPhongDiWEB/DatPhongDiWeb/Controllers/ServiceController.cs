using DatPhongDiWeb.Models.Service;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatPhongDiWeb.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/service/gets")]
        public JsonResult Gets()
        {
            var modules = ApiHelper<List<ServiceView>>.HttpGetAsync("service/gets");
            return Json(new { data = modules });
        }

        [HttpPost]
        [Route("/service/save")]
        public JsonResult Save([FromBody] SaveServiceReq request)
        {
            var result = ApiHelper<SaveServiceRes>.HttpPostAsync($"service/save", "POST", request);
            return Json(new { data = result });
        }
    }
}
