using DatPhongDiWeb.Models;
using DatPhongDiWeb.Models.TypeOfRoom;
using DatPhongDiWeb.Ultilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace DatPhongDiWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewRoomByRoomTypeId()
        {
            return View();
        }

        public IActionResult ViewTypeOfRooms()
        {
            var typeofRoom = ApiHelper<List<TypeofRoomView>>.HttpGetAsync("TypeOfRoom/GetsForView");
            return View(typeofRoom);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
