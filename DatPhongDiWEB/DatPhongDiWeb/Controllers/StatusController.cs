using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatPhongDiWeb.Models;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/status/getstatusbytableid/{id}")]
        public JsonResult GetStatusByTableId(int id)
        {
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"Status/GetStatusByTableId/{id}");
            return Json(new { data = status });
        }
    }
}
