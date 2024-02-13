using DbProjectAsync.Models;
using DbProjectAsync.ViewModels;

namespace DbProjectAsync.Interfaces
{
    public interface IStudent
    {
        #region Synchronous Services
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

        #endregion

        #region Asynchronous Services
        Task<ResponseModel<Guid>> AddStudentAsync(StudentViewModel model);
        Task<ResponseModel<StudentViewModel>> GetStudentByIdAsync(Guid studentId);
        Task<ResponseModel> UpdateStudentAsync(StudentViewModel model);
        Task<ResponseModel<List<StudentViewModel>>> GetStudentListAsync();
        Task<ResponseModel> DeleteStudentAsync(Guid studentId);
        Task<ResponseModel<List<StudentViewModel>>> GetStudentListByCityAsync(string cityName);
        Task<List<StudentViewModel>> GetStudentListByRegionAsync(string regionName);
        Task<List<StudentViewModel>> GetStudentListByStudentNameAsync(string studentName);
        Task<ResponseModel<List<string>>> GetRegionsAsync();
        #endregion
    }
}
