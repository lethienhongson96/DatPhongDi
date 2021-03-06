﻿using DatPhongDiWeb.Models.Service;
using DatPhongDiWeb.Models.Status;
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
            var result = ApiHelper<List<ServiceView>>.HttpGetAsync("service/gets");
            return Json(new { data = result });
        }

        [HttpGet]
        [Route("/service/status/gets")]
        public JsonResult GetStatus()
        {
            var status = ApiHelper<List<StatusView>>.HttpGetAsync($"Status/statusView/{(int)Common.Table.Service}");
            return Json(new { data = status });
        }

        [HttpPost]
        [Route("/service/save")]
        public JsonResult Save([FromBody] SaveServiceReq request)
        {
            var result = ApiHelper<SaveServiceRes>.HttpPostAsync($"service/save", "POST", request);
            return Json(new { data = result });
        }

        [Route("/service/Delete/{id}")]
        public IActionResult Delete(int id, ChangeStatusServiceReq req) 
        {
            req.Id = id;
            req.Status = 2;
            var result = ApiHelper<SaveServiceRes>.HttpPostAsync($"service/changeStatus", "PATCH", req);
            return Json(new { data = result });
        }
    }
}
