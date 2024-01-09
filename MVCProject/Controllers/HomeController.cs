using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;

namespace MVCProject.Controllers
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
            //return NotFound();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyName()
        {
            return Content("My Name is Irfan Sir");
        }
        public IActionResult GiveServerError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        public IActionResult GiveNotFoundError()
        {
            //return NotFound();
            return StatusCode(StatusCodes.Status404NotFound);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
