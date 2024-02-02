namespace MVCProject.Interfaces
{
    public interface IStudent//Services
    {
        List<CreateStudentViewModel> GetStudentList();
        CreateStudentViewModel? GetStudentById(int id);
        void SaveStudent(CreateStudentViewModel student);
        void SaveStudents(List<CreateStudentViewModel> students);
    }
    
}
