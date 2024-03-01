using DbProjectAsync.Interfaces;
using DbProjectAsync.Models;
using DbProjectAsync.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DbProjectAsync.Controllers
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
        [Authorize(Roles ="User,Admin")]//will allow both User as well as Admin
        public async Task<IActionResult> GetStudentList()
        {
            var result = await studentServices.GetStudentListAsync().ConfigureAwait(false);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Add incoming model to database,i.e. pass it to AddStudent Service
                var result = await studentServices.AddStudentAsync(model).ConfigureAwait(false);
                if (!result.IsSuccess)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
                return Ok(result);
            }
            string errors = string.Empty;
            foreach (var item in ModelState.Values.SelectMany(s=>s.Errors).ToList())
            {
                errors += item.ErrorMessage +";";
            }
            return BadRequest(new {ErrorMessage = errors, ErrorCode = 2001});
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        [HttpGet]
        public async Task<IActionResult> Index()//Index is a default page/view for this controller
        {//this will be used for student list
            //Call GetStudentList service and pass the result to view
            var result = await studentServices.GetStudentListAsync().ConfigureAwait(false);
            if (!result.IsSuccess)
            {
                return View("Error", new ErrorViewModel(result.ErrorCode, result.ErrorMessage));
            }
            return View(result.Result);
        }

        [HttpGet]
        public async Task<IActionResult> StudentListByRegion(string? region)
        {
            //if (string.IsNullOrEmpty(region))
            //{
            //    return View("Error");
            //}
            var regions = await studentServices.GetRegionsAsync().ConfigureAwait(false);
            if (!regions.IsSuccess)
            {
                return View("Error", new ErrorViewModel(regions.ErrorCode, regions.ErrorMessage));
            }
            ViewBag.Regions = regions.Result;

            if (!string.IsNullOrEmpty(region))
            {
                ViewBag.Region = region;
                var result = await studentServices.GetStudentListByRegionAsync(region).ConfigureAwait(false);
                //if (!result.IsSuccess)
                //{
                //    return View("Error", new ErrorViewModel(result.ErrorCode, result.ErrorMessage));
                //}
                return View(result);
            }
            return View();
        }
       

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Add incoming model to database,i.e. pass it to AddStudent Service
                var result = await studentServices.AddStudentAsync(model).ConfigureAwait(false);
                if (!result.IsSuccess)
                {
                    return View("Error", new ErrorViewModel(result.ErrorCode, result.ErrorMessage));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]Guid id)//in get action, data comes from query (route)
        {
            //pass this id to GetStudentById, and pass the result to view
            var result = await studentServices.GetStudentByIdAsync(id).ConfigureAwait(false);
            if (!result.IsSuccess)
            {
                return View("Error", new ErrorViewModel(result.ErrorCode, result.ErrorMessage));
            }
            return View(result.Result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                //pass this incoming model to the UpdateStudent service, if success then redirect
                //if unsuccessful then redirect to error view.
                var result = await studentServices.UpdateStudentAsync(model).ConfigureAwait(false);
                if (!result.IsSuccess)
                {
                    return View("Error", new ErrorViewModel(result.ErrorCode, result.ErrorMessage));
                }
                return RedirectToAction(nameof(Index));               
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //pass this id to DeleteStudent service, if success then redirect to list page
            //if unsuccessful then redirect to error page
            var result = await studentServices.DeleteStudentAsync(id).ConfigureAwait(false);
            if (!result.IsSuccess)
            {
                return View("Error", new ErrorViewModel(result.ErrorCode, result.ErrorMessage));
            }
            return RedirectToAction(nameof(Index));//single line instruction does not require { }
        }
    }
}
