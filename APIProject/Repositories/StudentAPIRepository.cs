using APIProject.Interfaces;
using APIProject.Models;
using DbProjectAsync.Interfaces;
using DbProjectAsync.Models;
using DbProjectAsync.ViewModels;
using System.Linq;

namespace APIProject.Repositories
{
    public class StudentAPIRepository : IStudentAPI
    {
        private readonly IStudent student;
        //Now data source will be API

        public StudentAPIRepository(IStudent student)
        {
            this.student = student;
        }

        public async Task<ResponseModel<Guid>> AddStudentAsync(StudentModel model)
        {
            var result = await student.AddStudentAsync(new StudentViewModel
            {
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Id = model.Id,
                Name = model.Name,
                PostalCode = model.PostalCode,
                Region = model.Region
            }).ConfigureAwait(false);
            return result;
        }

        public async Task<ResponseModel> DeleteStudentAsync(Guid studentId)
        {
            var result = await student.DeleteStudentAsync(studentId).ConfigureAwait(false);
            return result;
        }

        public async Task<ResponseModel<List<string>>> GetRegionsAsync()
        {
            var result = await student.GetRegionsAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<ResponseModel<StudentModel>> GetStudentByIdAsync(Guid studentId)
        {
            var result = await student.GetStudentByIdAsync(studentId).ConfigureAwait(false);
            return new ResponseModel<StudentModel>
            {
                ErrorCode = result.ErrorCode,
                ErrorMessage = result.ErrorMessage,
                IsSuccess = result.IsSuccess,
                Result = new StudentModel
                {
                    Address = result.Result.Address, City = result.Result.City,
                    Country = result.Result.Country,
                    Id = result.Result.Id,
                    Name = result.Result.Name,
                    PostalCode = result.Result.PostalCode,
                    Region = result.Result.Region
                }
            };
        }

        public async Task<ResponseModel<List<StudentModel>>> GetStudentListAsync()
        {
            var result = await student.GetStudentListAsync().ConfigureAwait(false);
            return new ResponseModel<List<StudentModel>>()
            {
                ErrorMessage = result.ErrorMessage,
                ErrorCode = result.ErrorCode,
                IsSuccess = result.IsSuccess,
                Result = result.Result.Select(s => new StudentModel
                {
                    Address = s.Address,
                    City = s.City,
                    Country = s.Country,
                    Id = s.Id,
                    Name = s.Name,
                    PostalCode = s.PostalCode,
                    Region = s.Region
                }).ToList()
            };
        }

        public async Task<ResponseModel<List<StudentModel>>> GetStudentListByCityAsync(string cityName)
        {
            var result = await student.GetStudentListByCityAsync(cityName).ConfigureAwait(false);
            return new ResponseModel<List<StudentModel>>()
            {
                ErrorMessage = result.ErrorMessage,
                ErrorCode = result.ErrorCode,
                IsSuccess = result.IsSuccess,
                Result = result.Result.Select(s => new StudentModel
                {
                    Address = s.Address,
                    City = s.City,
                    Country = s.Country,
                    Id = s.Id,
                    Name = s.Name,
                    PostalCode = s.PostalCode,
                    Region = s.Region
                }).ToList()
            };
        }

        public async Task<ResponseModel<List<StudentModel>>> GetStudentListByRegionAsync(string regionName)
        {
            var result = await student.GetStudentListByRegionAsync(regionName).ConfigureAwait(false);
            return new ResponseModel<List<StudentModel>>()
            {
                ErrorMessage = "Failed to get list of student",
                ErrorCode = 10001,
                IsSuccess = true,
                Result = result.Select(s => new StudentModel
                {
                    Address = s.Address,
                    City = s.City,
                    Country = s.Country,
                    Id = s.Id,
                    Name = s.Name,
                    PostalCode = s.PostalCode,
                    Region = s.Region
                }).ToList()
            };
        }

        public async Task<ResponseModel<List<StudentModel>>> GetStudentListByStudentNameAsync(string studentName)
        {
            var result = await student.GetStudentListByStudentNameAsync(studentName).ConfigureAwait(false);
            return new ResponseModel<List<StudentModel>>()
            {
                ErrorMessage = "Failed to get list of student",
                ErrorCode = 10002,
                IsSuccess = true,
                Result = result.Select(s => new StudentModel
                {
                    Address = s.Address,
                    City = s.City,
                    Country = s.Country,
                    Id = s.Id,
                    Name = s.Name,
                    PostalCode = s.PostalCode,
                    Region = s.Region
                }).ToList()
            };
        }

        public async Task<ResponseModel> UpdateStudentAsync(StudentModel model)
        {
            var result = await student.UpdateStudentAsync(new StudentViewModel
            {
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Id = model.Id,
                Name = model.Name,
                PostalCode = model.PostalCode,
                Region = model.Region
            }).ConfigureAwait(false);
            return result;
        }
    }
}
