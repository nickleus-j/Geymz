using Geymz.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Geymz.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Snake()
        {
            return View();
        }
        public IActionResult Pong()
        {
            return View();
        }
        public IActionResult TicTacToe()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AirHockey()
        {
            return View();
        }
        public IActionResult Tangram()
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