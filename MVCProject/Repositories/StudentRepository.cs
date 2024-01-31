using MVCProject.Interfaces;

namespace MVCProject.Repositories
{
    public class StudentRepository : IStudent
    {
        private List<Student> studentList;
        public StudentRepository()
        {
            studentList = new List<Student>();
            
            studentList.AddRange(new List<Student> 
            {
                new Student() { Id = 1, Name = "abcd", Email = "a@a.com", Phone = "111" },
                new Student() { Id = 2, Name = "qqq", Email = "q@a.com", Phone = "222" },
                new Student() { Id = 3, Name = "www", Email = "w@a.com", Phone = "333" },
                new Student() { Id = 4, Name = "eee", Email = "e@a.com", Phone = "444" }
            });
        }
        public CreateStudentViewModel? GetStudentById(int id)
        {
            CreateStudentViewModel? viewModel = null; //local variable
            var student = studentList.Where(s=>s.Id == id).FirstOrDefault();
            if (student != null)
            {
                viewModel = new CreateStudentViewModel();
                viewModel.Id = student.Id;
                viewModel.Name = student.Name;
                viewModel.Email = student.Email;
                viewModel.Phone = student.Phone;
            }
            return viewModel;
        }

        public List<CreateStudentViewModel> GetStudentList()
        {
            List<CreateStudentViewModel> students = new List<CreateStudentViewModel>();
            foreach (var student in studentList)
            {
                if(student is not null)
                {
                    students.Add(new CreateStudentViewModel
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        Phone = student.Phone
                    });
                }
            }
            return students;
        }

        public void SaveStudent(CreateStudentViewModel student)
        {
            studentList.Add(new Student
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email ?? string.Empty,
                Phone = student.Phone ?? string.Empty
            });
        }
    }
}
