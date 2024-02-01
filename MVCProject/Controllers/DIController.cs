using Microsoft.AspNetCore.Mvc;
using MVCProject.Interfaces;

namespace MVCProject.Controllers
{
    public class DIController1(IStudent studentService) : Controller
    {
        //this controller uses new method of dependency injection,
        //where we do not require private variable to keep it alive 
        //in the whole controller
    }
    public class DIController : Controller
    {
        /// <summary>
        /// Dependency Injection is a technique to inject the class or 
        /// service/interface into the class using constructor
        /// For this we accept the class or interface/service as input parameter 
        /// to the constructor.
        /// The injected service in this example is IStudent with a name studentService
        /// this object "studentService" is a reference variable, which holds the 
        /// address of interface/service but it is available only within constructor.
        /// To make it available for other methods or actions within this Controller class
        /// we have to create another private readonly reference variable and assign
        /// the injected reference to it.
        /// </summary>
        /// <returns></returns>
        /// 
        private readonly IStudent studentService;
        public DIController(IStudent studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult StudentList()
        {
           var model = studentService.GetStudentList();
            return View(model);
        }

        [HttpGet]
        public IActionResult StudentDetail(int id)
        {
            var student = studentService.GetStudentById(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                studentService.SaveStudent(model);
            }
            ModelState.AddModelError("", "This is additional error message");
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateBSValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBSValidation(CreateStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                studentService.SaveStudent(model);
            }
            ModelState.AddModelError("", "This is additional error message");
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateStudentList()
        {
            List<CreateStudentViewModel> students = new List<CreateStudentViewModel>
            {
                new CreateStudentViewModel(),
                new CreateStudentViewModel(),
                new CreateStudentViewModel(),
                new CreateStudentViewModel(),
            };
            return View(students);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudentList(List<CreateStudentViewModel> model)
        {
            if (ModelState.IsValid)
            {
                studentService.SaveStudents(model);
            }
            return View(model);
        }
    }
}
