using APIProject.Interfaces;
using APIProject.Models;
using JWTProject.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace APIProject.Repositories
{
    public class StudentAPIRepository : IStudentAPI
    {
        private readonly IJWTServices jWTServices;
        private readonly string baseUrl;

        public StudentAPIRepository(IConfiguration configuration, IJWTServices jWTServices)
        {
            this.jWTServices = jWTServices;
            this.baseUrl = configuration.GetSection("EndPointUrl").Value ??
            throw new Exception("Server not found");
        }
        public async Task<string> GetToken()
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("password", "Abcd@1234");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("/Home/GetToken");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenModel>(responseString);
            return result.token;
        }
        public Task<ResponseModel<Guid>> AddStudentAsync(StudentModel model)
        {
            throw new NotImplementedException();
        }

        //public async Task<ResponseModel<Guid>> AddStudentAsync(StudentModel model)
        //{
        //    var responseModel = new ResponseModel();
        //    try
        //    {
        //        var tokenResponse = await jWTServices.ReadToken();
        //        if (!tokenResponse.IsSuccess) throw new Exception($"Error code: {tokenResponse.ErrorCode}, Error message : {tokenResponse.ErrorMessage}");
        //        var token = tokenResponse.Result;
        //        using HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(baseUrl);
        //        var data = JsonConvert.SerializeObject(model);
        //        var content = new StringContent(data, Encoding.UTF8, "application/json");
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var response = await client.PostAsync("/Student/AddRecord", content);
        //        response.EnsureSuccessStatusCode();
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<ResponseModel>(responseString);
        //        responseModel = result;
        //    }
        //    catch (Exception ex)
        //    {
        //        responseModel!.ErrorCode = 8001;
        //        responseModel.ErrorMessage = ex.Message;
        //    }

        //    return responseModel!;
        //}

        public Task<ResponseModel> DeleteStudentAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<string>>> GetRegionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<StudentModel>> GetStudentByIdAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<StudentModel>>> GetStudentListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<StudentModel>>> GetStudentListByCityAsync(string cityName)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<StudentModel>>> GetStudentListByRegionAsync(string regionName)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<StudentModel>>> GetStudentListByStudentNameAsync(string studentName)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateStudentAsync(StudentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
