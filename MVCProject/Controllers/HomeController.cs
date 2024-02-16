using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;
using RandomNumber;


namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }
        public IActionResult Index()
        {
            var number = RandomNumberClass.GetRandomNumber();
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

       
    }
}
