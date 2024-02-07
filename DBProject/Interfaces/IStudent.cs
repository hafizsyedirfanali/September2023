using DBProject.ViewModels;

namespace DBProject.Interfaces
{
    public interface IStudent
    {
        Guid AddStudent(StudentViewModel model);
        StudentViewModel GetStudentById(Guid studentId);
        bool UpdateStudent(StudentViewModel model);
        List<StudentViewModel> GetStudentList();
        bool DeleteStudent(Guid studentId);
    }
}
