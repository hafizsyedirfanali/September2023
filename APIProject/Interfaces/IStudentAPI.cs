using APIProject.Models;

namespace APIProject.Interfaces
{
    public interface IStudentAPI
    {
        Task<string> GetToken();
        Task<ResponseModel<Guid>> AddStudentAsync(StudentModel model);
        Task<ResponseModel<StudentModel>> GetStudentByIdAsync(Guid studentId);
        Task<ResponseModel> UpdateStudentAsync(StudentModel model);
        Task<ResponseModel<List<StudentModel>>> GetStudentListAsync();
        Task<ResponseModel> DeleteStudentAsync(Guid studentId);
        Task<ResponseModel<List<StudentModel>>> GetStudentListByCityAsync(string cityName);
        Task<ResponseModel<List<StudentModel>>> GetStudentListByRegionAsync(string regionName);
        Task<ResponseModel<List<StudentModel>>> GetStudentListByStudentNameAsync(string studentName);
        Task<ResponseModel<List<string>>> GetRegionsAsync();
    }
}
