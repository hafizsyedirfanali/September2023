using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class DataController : Controller
    {
        public IActionResult ViewDataAction()
        {
            ViewData["WelcomeText"] = "Hello from Irfan Sir. Its cold today";
            return View();
        }
    }
}
