using DbProjectAsync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using System.Diagnostics;
using RandomNumber;
using DbProjectAsync.Interfaces;

namespace DbProjectAsync.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IOptions<ComplexObjectClass> options;
        private readonly IJWTServices jWTServices;

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration,
            IOptions<ComplexObjectClass> options,
            IJWTServices jWTServices)
        {
            _logger = logger;
            this.configuration = configuration;
            this.options = options;
            this.jWTServices = jWTServices;
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
        public IActionResult Index()
        {
            var number = RandomNumberClass.GetRandomNumber();
            _logger.LogInformation("Hello from logger");
            var value = configuration.GetSection("MyApplicationName").Value;
            var version = configuration.GetValue<int>("MyApplicationVersion");
            var complexObject = options;
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogCritical("this is a critical message");
            _logger.LogError("this is an error message");
            _logger.LogWarning("this is a warning message");
            return View();
        }

        
    }
}
