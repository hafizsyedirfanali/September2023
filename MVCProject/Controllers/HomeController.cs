using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;
using RandomNumber;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using MVCProject.Interfaces;


namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> localizer;
        private readonly IJWTServices jWTServices;

        public HomeController(IHtmlLocalizer<HomeController> localizer, IJWTServices jWTServices)
        {
            this.localizer = localizer;
            this.jWTServices = jWTServices;
        }
        public IActionResult Index()
        {
            ViewData["HelloWorld"] = localizer["HelloWorld"];
            var number = RandomNumberClass.GetRandomNumber();
            //return NotFound();
            Response.Cookies.Append("Key", "Value", new CookieOptions { Expires= DateTime.Now.AddDays(1)});
            
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetToken([FromHeader] string password)
        {
            if (password == "Abcd@1234")
            {
                var result = jWTServices.GenerateToken();
                return Ok(new { token = result });
            }
            return BadRequest("Incorrect Credentials");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CultureManagement(string Culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30), SameSite = SameSiteMode.None, Secure = true });
            return LocalRedirect(returnUrl);
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
