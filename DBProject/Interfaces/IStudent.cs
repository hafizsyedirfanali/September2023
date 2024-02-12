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
        //Searching Services (These will return List of Students)
        //1. Find by City, Region, Country, etc.
        //2. Find by Name (Matching name)
        List<StudentViewModel> GetStudentListByCity(string cityName);
        List<StudentViewModel> GetStudentListByRegion(string regionName);
        List<StudentViewModel> GetStudentListByCountry(string countryName);
        List<StudentViewModel> GetStudentListByStudentName(string studentName);
        List<string> GetRegions();
    }
}
