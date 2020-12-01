using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DatPhongDiWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TestUploadImages()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/TestUploadImages")]
        public IActionResult TestUploadImages(List<IFormFile> files)
        {
            return View();
        }
    }
}
