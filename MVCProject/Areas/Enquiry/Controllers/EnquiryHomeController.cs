using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Areas.Enquiry.Controllers
{
    [Area("Enquiry")]
    public class EnquiryHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
