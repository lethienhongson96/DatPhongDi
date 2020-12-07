using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DatPhongDiWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TestUploadImages()
        {
            return View();
        }

        

        
    }
}
