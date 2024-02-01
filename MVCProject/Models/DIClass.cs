using MVCProject.Interfaces;

namespace MVCProject.Models
{
    public class DIClass1
    {
        private readonly IStudent studentService;

        public DIClass1(IStudent studentService)
        {
            this.studentService = studentService;
        }
    }
    public class DIClass2
    {
        private readonly IStudent studentService;

        public DIClass2(IStudent studentService)
        {
            this.studentService = studentService;
        }
    }

    public class DIClass3(IStudent studentService)
    {

    }
}
