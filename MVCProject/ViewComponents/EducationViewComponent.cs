using Microsoft.AspNetCore.Mvc;
using MVCProject.Interfaces;

namespace MVCProject.ViewComponents
{
    public class EducationViewComponent : ViewComponent
    {
        private readonly IStudent student;

        public EducationViewComponent(IStudent student)
        {
            this.student = student;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = student.GetStudentList();
            return View(model);
        }
    }
}
