namespace MVCProject.Interfaces
{
    public interface IStudent
    {
        List<CreateStudentViewModel> GetStudentList();
        CreateStudentViewModel? GetStudentById(int id);
        void SaveStudent(CreateStudentViewModel student);
        void SaveStudents(List<CreateStudentViewModel> students);
    }
    
}
