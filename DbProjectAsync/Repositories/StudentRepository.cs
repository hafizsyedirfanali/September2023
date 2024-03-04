using DbProjectAsync.Data;
using DbProjectAsync.Interfaces;
using DbProjectAsync.Models;
using DbProjectAsync.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace DbProjectAsync.Repositories
{
    /// <summary>
    /// To create a class for implementation of an Interface,
    /// 1. Inherit it from Interface
    /// 2. Implement all the members of interface
    /// 3. To use these services this Interface:Repository Contract must be registered
    /// in program.cs services as Transient, because Database service is not managed 
    /// by garbage collector and Entity Framework does not allow multiple instances for
    /// a database context. An EF does not allow parallel connections.
    /// Transient services free the instance after use, which is efficient for third-
    /// party services like SQL, APIs, SMS, Email, etc
    /// </summary>
    public class StudentRepository : IStudent
    {
        /// <summary>
        /// EF uses LINQ Language for database operations. EF translates it into SQL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        private readonly ApplicationDbContext dbContext;
        public StudentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Guid AddStudent(StudentViewModel model)
        {
            Student student = new Student()
            {
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Name = model.Name,
                PostalCode = model.PostalCode,
                Region = model.Region
            };

            dbContext.Students.Add(student);
            //after adding student entity to Students DbSet Property, EF Change Tracker
            //will track this change. then we have to apply this change to SQL Server
            dbContext.SaveChanges();
            //this SaveChanges will translate the change into SQL query and apply to 
            //the sql server.
            //After SaveChanges we can get Id of added student from student object
            var id = student.Id;
            return id;
        }
        public async Task<ResponseModel<Guid>> AddStudentAsync(StudentViewModel model)
        {
            var responseModel = new ResponseModel<Guid>();
            try
            {
                //throw new Exception("Cant get list of student");
                Student student = new Student()
                {
                    Address = model.Address,
                    City = model.City,
                    Country = model.Country,
                    Name = model.Name,
                    PostalCode = model.PostalCode,
                    Region = model.Region
                };
                await dbContext.Students.AddAsync(student);
                //after adding student entity to Students DbSet Property, EF Change Tracker
                //will track this change. then we have to apply this change to SQL Server
                await dbContext.SaveChangesAsync();
                //this SaveChanges will translate the change into SQL query and apply to 
                //the sql server.
                //After SaveChanges we can get Id of added student from student object
                var id = student.Id;
                responseModel.Result = id;
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = 1001;
                responseModel.ErrorMessage = "Failed to Add Student";
                Log.Logger.Error($"Error Code:{responseModel.ErrorCode}");
                Log.Logger.Error($"Error Message:{responseModel.ErrorMessage}");
                Log.Logger.Error(ex.Message);
                Log.Logger.Error($"Stack Trace:{ex.StackTrace ?? "Nil"}");
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "Nil";
                Log.Logger.Error($"Inner Exception:{innerException}");
                Log.Logger.Information(JsonConvert.SerializeObject(model));
            }
            return responseModel;
        }

        public bool DeleteStudent(Guid studentId)
        {
            //to delete we have to bring the student of given Id
            //As we will delete the student, i.e. we will perform another database
            //operation within the same scope
            //we cannot use AsNoTracking with Find method, so if we have to call
            //AsNoTracking we have to use firstordefault method
            var student = dbContext.Students.Find(studentId);
            if(student is not null)
            {
                dbContext.Students.Remove(student);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<ResponseModel> DeleteStudentAsync(Guid studentId)
        {
            var responseModel = new ResponseModel();
            //to delete we have to bring the student of given Id
            //As we will delete the student, i.e. we will perform another database
            //operation within the same scope
            //we cannot use AsNoTracking with Find method, so if we have to call
            //AsNoTracking we have to use firstordefault method
            try
            {
                var student = await dbContext.Students.FindAsync(studentId);
                if (student is not null)
                {
                    dbContext.Students.Remove(student);
                    await dbContext.SaveChangesAsync();
                    responseModel.IsSuccess = true;
                }
                else
                {
                    responseModel.ErrorCode = 1007;
                    responseModel.ErrorMessage = $"Student with Id {studentId} not found";
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = 1002;
                responseModel.ErrorMessage = "Failed to delete student";
                Log.Logger.Error($"Error Code:{responseModel.ErrorCode}");
                Log.Logger.Error($"Error Message:{responseModel.ErrorMessage}");
                Log.Logger.Error(ex.Message);
                Log.Logger.Error($"Stack Trace:{ex.StackTrace ?? "Nil"}");
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "Nil";
                Log.Logger.Error($"Inner Exception:{innerException}");
            }
            return responseModel;
        }

        public List<string> GetRegions()
        {
            var regions = dbContext.Students.AsNoTracking()
                .Select(s => s.Region).ToList();
            return regions;
            //var twoColumns = dbContext.Students.AsNoTracking()
            //    .Select(s => new 
            //    {
            //        s.Region, 
            //        s.City
            //    }).ToList();
        }
        public async Task<ResponseModel<List<string>>> GetRegionsAsync()
        {
            var responseModel = new ResponseModel<List<string>>();
            try
            {
                var regions = await dbContext.Students.AsNoTracking()
                    .Select(s => s.Region).ToListAsync();
                responseModel.Result = regions;
                responseModel.IsSuccess = true;
            }
            catch (Exception ex) 
            {
                responseModel.ErrorCode = 1003;
                responseModel.ErrorMessage = "Failed to get regions";
                Log.Logger.Error($"Error Code:{responseModel.ErrorCode}");
                Log.Logger.Error($"Error Message:{responseModel.ErrorMessage}");
                Log.Logger.Error(ex.Message);
                Log.Logger.Error($"Stack Trace:{ex.StackTrace ?? "Nil"}");
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "Nil";
                Log.Logger.Error($"Inner Exception:{innerException}");
            }
            return responseModel;
            //var twoColumns = dbContext.Students.AsNoTracking()
            //    .Select(s => new 
            //    {
            //        s.Region, 
            //        s.City
            //    }).ToList();
        }

        public StudentViewModel GetStudentById(Guid studentId)
        {
            //here we are not performing multiple database operations on 
            //same instance. hence we can disable change tracker. so we will use firstordefault
            var student = dbContext.Students.AsNoTracking()
                .FirstOrDefault(s=>s.Id ==  studentId);
            StudentViewModel model = new StudentViewModel();
            if(student is not null)
            {
                model.Address = student.Address;
                model.City = student.City;
                model.Country = student.Country;
                model.Name = student.Name;
                model.PostalCode = student.PostalCode;
                model.Region = student.Region;
                model.Id = student.Id;
                //we have mapped two objects manually
                //for more properties it will be difficult to map manually
                //you can use third party services for this purpose.
                //for example AutoMapper
            }
            return model;
        }
        public async Task<ResponseModel<StudentViewModel>> GetStudentByIdAsync(Guid studentId)
        {
            var responseModel = new ResponseModel<StudentViewModel>();
            //here we are not performing multiple database operations on 
            //same instance. hence we can disable change tracker. so we will use firstordefault
            try
            {
                var student = await dbContext.Students.AsNoTracking()
                        .FirstOrDefaultAsync(s => s.Id == studentId);
                StudentViewModel model = new StudentViewModel();
                if (student is not null)
                {
                    model.Address = student.Address;
                    model.City = student.City;
                    model.Country = student.Country;
                    model.Name = student.Name;
                    model.PostalCode = student.PostalCode;
                    model.Region = student.Region;
                    model.Id = student.Id;
                    //we have mapped two objects manually
                    //for more properties it will be difficult to map manually
                    //you can use third party services for this purpose.
                    //for example AutoMapper
                }
                responseModel.Result = model;
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = 1004;
                responseModel.ErrorMessage = "Failed to get student record";
                Log.Logger.Error($"Error Code:{responseModel.ErrorCode}");
                Log.Logger.Error($"Error Message:{responseModel.ErrorMessage}");
                Log.Logger.Error(ex.Message);
                Log.Logger.Error($"Stack Trace:{ex.StackTrace ?? "Nil"}");
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "Nil";
                Log.Logger.Error($"Inner Exception:{innerException}");
            }
            return responseModel;
        }

        public List<StudentViewModel> GetStudentList()
        {
            List<StudentViewModel> list = new List<StudentViewModel>();
            var students = dbContext.Students.AsNoTracking().ToList();
            foreach (var student in students)
            {
                list.Add(new StudentViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Address = student.Address,
                    City = student.City,
                    Country = student.Country,
                    PostalCode = student.PostalCode,
                    Region = student.Region,
                });
            }
            //following method will perform above operation in one instruction
            var students1 = dbContext.Students.AsNoTracking()
                .Select(s => new StudentViewModel
                {
                    Address = s.Address,
                    City = s.City,
                    Country = s.Country,
                    Name = s.Name,
                    PostalCode = s.PostalCode,
                    Region = s.Region,
                    Id = s.Id
                }).ToList();
            return list;
        }
        public async Task<ResponseModel<List<StudentViewModel>>> GetStudentListAsync()
        {
            var responseModel = new ResponseModel<List<StudentViewModel>>();
            try
            {
                List<StudentViewModel> list = new List<StudentViewModel>();
                var students = await dbContext.Students.AsNoTracking().ToListAsync();
                foreach (var student in students)
                {
                    list.Add(new StudentViewModel
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Address = student.Address,
                        City = student.City,
                        Country = student.Country,
                        PostalCode = student.PostalCode,
                        Region = student.Region,
                    });
                }
                //following method will perform above operation in one instruction
                var students1 = await dbContext.Students.AsNoTracking()
                    .Select(s => new StudentViewModel
                    {
                        Address = s.Address,
                        City = s.City,
                        Country = s.Country,
                        Name = s.Name,
                        PostalCode = s.PostalCode,
                        Region = s.Region,
                        Id = s.Id
                    }).ToListAsync();
                responseModel.Result = list;
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = 1005;
                responseModel.ErrorMessage = "Failed to get student list";
                Log.Logger.Error($"Error Code:{responseModel.ErrorCode}");
                Log.Logger.Error($"Error Message:{responseModel.ErrorMessage}");
                Log.Logger.Error(ex.Message);
                Log.Logger.Error($"Stack Trace:{ex.StackTrace??"Nil"}");
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "Nil";
                Log.Logger.Error($"Inner Exception:{innerException}");
            }
            return responseModel;
        }

        public List<StudentViewModel> GetStudentListByCity(string cityName)
        {
            var students = dbContext.Students.AsNoTracking()
                .Where(s=>s.City.ToLower() == cityName.ToLower())//Case In-Sensitive
                .Select(s => new StudentViewModel
                {
                    Address = s.Address,
                    City = s.City,
                    Country = s.Country,
                    Name = s.Name,
                    PostalCode = s.PostalCode,
                    Region = s.Region,
                    Id = s.Id
                }).ToList();
            return students;
        }
        public async Task<ResponseModel<List<StudentViewModel>>> GetStudentListByCityAsync(string cityName)
        {
            var responseModel = new ResponseModel<List<StudentViewModel>>();
            try
            {
                var students = await dbContext.Students.AsNoTracking()
                        .Where(s => s.City.ToLower() == cityName.ToLower())//Case In-Sensitive
                        .Select(s => new StudentViewModel
                        {
                            Address = s.Address,
                            City = s.City,
                            Country = s.Country,
                            Name = s.Name,
                            PostalCode = s.PostalCode,
                            Region = s.Region,
                            Id = s.Id
                        }).ToListAsync();
                responseModel.Result = students;
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = 1006;
                responseModel.ErrorMessage = "Failed to get student list by city";
                Log.Logger.Error($"Error Code:{responseModel.ErrorCode}");
                Log.Logger.Error($"Error Message:{responseModel.ErrorMessage}");
                Log.Logger.Error(ex.Message);
                Log.Logger.Error($"Stack Trace:{ex.StackTrace ?? "Nil"}");
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "Nil";
                Log.Logger.Error($"Inner Exception:{innerException}");
            }
            return responseModel;
        }

        public List<StudentViewModel> GetStudentListByCountry(string countryName)
        {
            var students = dbContext.Students.AsNoTracking()
               .Where(s => s.Country.ToLower() == countryName.ToLower())//Case In-Sensitive
               .Select(s => new StudentViewModel
               {
                   Address = s.Address,
                   City = s.City,
                   Country = s.Country,
                   Name = s.Name,
                   PostalCode = s.PostalCode,
                   Region = s.Region,
                   Id = s.Id
               }).ToList();
            return students;
        }
        public async Task<List<StudentViewModel>> GetStudentListByCountryAsync(string countryName)
        {
            var students = await dbContext.Students.AsNoTracking()
               .Where(s => s.Country.ToLower() == countryName.ToLower())//Case In-Sensitive
               .Select(s => new StudentViewModel
               {
                   Address = s.Address,
                   City = s.City,
                   Country = s.Country,
                   Name = s.Name,
                   PostalCode = s.PostalCode,
                   Region = s.Region,
                   Id = s.Id
               }).ToListAsync();
            return students;
        }

        public List<StudentViewModel> GetStudentListByRegion(string regionName)
        {
            var students = dbContext.Students.AsNoTracking()
               .Where(s => s.Region.ToLower() == regionName.ToLower())//Case In-Sensitive
               .Select(s => new StudentViewModel
               {
                   Address = s.Address,
                   City = s.City,
                   Country = s.Country,
                   Name = s.Name,
                   PostalCode = s.PostalCode,
                   Region = s.Region,
                   Id = s.Id
               }).ToList();
            return students;
        }

        public async Task<List<StudentViewModel>> GetStudentListByRegionAsync(string regionName)
        {
            var students = await dbContext.Students.AsNoTracking()
               .Where(s => s.Region.ToLower() == regionName.ToLower())//Case In-Sensitive
               .Select(s => new StudentViewModel
               {
                   Address = s.Address,
                   City = s.City,
                   Country = s.Country,
                   Name = s.Name,
                   PostalCode = s.PostalCode,
                   Region = s.Region,
                   Id = s.Id
               }).ToListAsync();
            return students;
        }

        public List<StudentViewModel> GetStudentListByStudentName(string studentName)
        {
            //Abdul Rahim -- In database
            //Abdul -- search string
            var students = dbContext.Students.AsNoTracking()
               .Where(s => s.Name.ToLower().Contains(studentName.ToLower()))//Manual Case In-Sensitive
               .Where(s => s.Name.Contains(studentName, StringComparison.OrdinalIgnoreCase))//Case In-Sensitive using StringComparision Class
               .Select(s => new StudentViewModel
               {
                   Address = s.Address,
                   City = s.City,
                   Country = s.Country,
                   Name = s.Name,
                   PostalCode = s.PostalCode,
                   Region = s.Region,
                   Id = s.Id
               }).ToList();
            return students;
        }
        public async Task<List<StudentViewModel>> GetStudentListByStudentNameAsync(string studentName)
        {
            //Abdul Rahim -- In database
            //Abdul -- search string
            var students = await dbContext.Students.AsNoTracking()
               .Where(s => s.Name.ToLower().Contains(studentName.ToLower()))//Manual Case In-Sensitive
               //.Where(s => s.Name.Contains(studentName, StringComparison.OrdinalIgnoreCase))//Case In-Sensitive using StringComparision Class
               .Select(s => new StudentViewModel
               {
                   Address = s.Address,
                   City = s.City,
                   Country = s.Country,
                   Name = s.Name,
                   PostalCode = s.PostalCode,
                   Region = s.Region,
                   Id = s.Id
               }).ToListAsync();
            return students;
        }

        public bool UpdateStudent(StudentViewModel model)
        {
            var student = dbContext.Students.Find(model.Id);
            if(student != null)
            {
                student.Address = model.Address;
                student.City = model.City;
                student.Country = model.Country;
                student.PostalCode = model.PostalCode;
                student.Region = model.Region;
                student.Name = model.Name;
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<ResponseModel> UpdateStudentAsync(StudentViewModel model)
        {
            var responseModel = new ResponseModel();
            try
            {
                var student = await dbContext.Students.FindAsync(model.Id);
                if (student != null)
                {
                    student.Address = model.Address;
                    student.City = model.City;
                    student.Country = model.Country;
                    student.PostalCode = model.PostalCode;
                    student.Region = model.Region;
                    student.Name = model.Name;
                    await dbContext.SaveChangesAsync();
                    responseModel.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorCode = 1006;
                responseModel.ErrorMessage = "Failed to update student";
                Log.Logger.Error($"Error Code:{responseModel.ErrorCode}");
                Log.Logger.Error($"Error Message:{responseModel.ErrorMessage}");
                Log.Logger.Error(ex.Message);
                Log.Logger.Error($"Stack Trace:{ex.StackTrace ?? "Nil"}");
                var innerException = ex.InnerException != null ? ex.InnerException.Message : "Nil";
                Log.Logger.Error($"Inner Exception:{innerException}");
            }
            return responseModel;
        }
    }
}
