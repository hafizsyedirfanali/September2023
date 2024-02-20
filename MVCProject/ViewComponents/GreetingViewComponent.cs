using Microsoft.AspNetCore.Mvc;

namespace MVCProject.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string message = "Hello from view component";
            return View("Default", message);
        }
    }
}
