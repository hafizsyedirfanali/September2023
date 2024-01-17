using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class ModelBindingController : Controller
    {
        public IActionResult StudentList()
        {
            //on a page/view only one model can be binded. therefore the name model is sufficient
            var model = new List<Student>();
            model.Add(new Student() { Id = 1, Name = "Abcd", Email = "a@a.com", Phone = "111" });
            model.Add(new Student() { Id = 2, Name = "qqq", Email = "q@a.com", Phone = "222" });
            model.Add(new Student() { Id = 3, Name = "www", Email = "w@a.com", Phone = "333" });
            model.Add(new Student() { Id = 4, Name = "eee", Email = "e@a.com", Phone = "444" });
            return View(model);
        }
    }
    //public class Student
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string Phone { get; set; }
    //}
}
