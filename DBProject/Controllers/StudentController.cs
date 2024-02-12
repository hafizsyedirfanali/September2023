using DBProject.Interfaces;
using DBProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DBProject.Controllers
{
    /// <summary>
    /// This Controller will have only Business Logic Layer and 
    /// Data Access Layer is shifted to the repository
    /// </summary>
    public class StudentController : Controller
    {
        private readonly IStudent studentServices;

        public StudentController(IStudent studentServices)
        {
            this.studentServices = studentServices;
        }
        [HttpGet]
        public IActionResult Index()//Index is a default page/view for this controller
        {//this will be used for student list
            //Call GetStudentList service and pass the result to view
            var result = studentServices.GetStudentList();
            return View(result);
        }

        [HttpGet]
        public IActionResult StudentListByRegion(string? region)
        {
            //if (string.IsNullOrEmpty(region))
            //{
            //    return View("Error");
            //}
            var regions = studentServices.GetRegions();
            ViewBag.Regions = regions;

            if (!string.IsNullOrEmpty(region))
            {
                ViewBag.Region = region;
                var result = studentServices.GetStudentListByRegion(region);
                return View(result);
            }
            return View();
        }
       

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Add incoming model to database,i.e. pass it to AddStudent Service
                var result = studentServices.AddStudent(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit([FromRoute]Guid id)//in get action, data comes from query (route)
        {
            //pass this id to GetStudentById, and pass the result to view
            var result = studentServices.GetStudentById(id);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                //pass this incoming model to the UpdateStudent service, if success then redirect
                //if unsuccessful then redirect to error view.
                var result = studentServices.UpdateStudent(model);
                if(result == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View("Error");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] Guid id)
        {
            //pass this id to DeleteStudent service, if success then redirect to list page
            //if unsuccessful then redirect to error page
            var result = studentServices.DeleteStudent(id);
            if(result == true) return RedirectToAction(nameof(Index));//single line instruction does not require { }
            return View("Error");
        }
    }
}
