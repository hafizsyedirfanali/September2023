using EFProject.Data;
using EFProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFProject.Controllers
{
    /// <summary>
    /// For Installing EF in a project we need 
    /// 1. Packages (Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools
    /// 2. DbContext, which is a class that inherits base class "DbContext". we name it 
    /// as OurAppDbContext, or e.g. LibraryDbContext, StudentDbContext, ShopDbContext
    /// Note : For using Microsoft Identity we have to inherit from IdentityDbContext, which require Microsft.AspNetCore.Identity.EntityFramworkCore package
    /// 3. Connection String: it is a string that specify the target database and database server, with required configurations. We keep it into appsettings.json file
    /// 4. Registration of database Service
    /// With these above four options we are ready with Entity framework.
    /// 5. To use EF in a class we need to inject OurAppDbContext into that class.
    /// This will enable EF with Code first approach.
    /// Another approach is Database first approach.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EFDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, EFDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var students = dbContext.Students;
            return View();
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
