using DbProjectAsync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using System.Diagnostics;
using RandomNumber;

namespace DbProjectAsync.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly IOptions<ComplexObjectClass> options;

        public HomeController(ILogger<HomeController> logger, 
            IConfiguration configuration,
            IOptions<ComplexObjectClass> options)
        {
            _logger = logger;
            this.configuration = configuration;
            this.options = options;
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
