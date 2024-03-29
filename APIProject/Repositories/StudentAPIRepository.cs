﻿using APIProject.Interfaces;
using APIProject.Models;
using JWTProject.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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
        public async Task SaveToken(string token)
        {
            var saveResult = await jWTServices.SaveToken(token);
        }
        public async Task<string> GetToken()
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("password", "Abcd@1234");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("/Home/GetToken");
            response.EnsureSuccessStatusCode();
            //if (response.IsSuccessStatusCode)
            //{

            //}
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenModel>(responseString);
            return result.token;
        }

        public async Task<ResponseModel> UpdateStudentAsync(StudentModel model)
        {
            var responseModel = new ResponseModel();
            try
            {
                var tokenResponse = await jWTServices.ReadToken();
                if (!tokenResponse.IsSuccess) throw new Exception($"Error code: {tokenResponse.ErrorCode}, Error message : {tokenResponse.ErrorMessage}");
                var token = tokenResponse.Result;
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync("/Student/UpdateStudent", content);
                // response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseModel>(responseString);
                responseModel = result;
            }
            catch (Exception ex)
            {
                responseModel!.ErrorCode = 8001;
                responseModel.ErrorMessage = ex.Message;
            }

            return responseModel!;
        }
        public async Task<ResponseModel<Guid>> AddStudentAsync(StudentModel model)
        {
            var responseModel = new ResponseModel<Guid>();
            try
            {
                var tokenResponse = await jWTServices.ReadToken();
                if (!tokenResponse.IsSuccess) throw new Exception($"Error code: {tokenResponse.ErrorCode}, Error message : {tokenResponse.ErrorMessage}");
                var token = tokenResponse.Result;
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                var data = JsonConvert.SerializeObject(model);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsync("/Student/AddRecord", content);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseModel<Guid>>(responseString);
                responseModel = result;
            }
            catch (Exception ex)
            {
                responseModel!.ErrorCode = 8001;
                responseModel.ErrorMessage = ex.Message;
            }

            return responseModel!;
        }

        public async Task<ResponseModel> DeleteStudentAsync(Guid studentId)
        {
            var responseModel = new ResponseModel();
            try
            {
                var tokenResponse = await jWTServices.ReadToken();
                if (!tokenResponse.IsSuccess) throw new Exception($"Error code: {tokenResponse.ErrorCode}, Error message : {tokenResponse.ErrorMessage}");
                var token = tokenResponse.Result;
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                
                //var data = JsonConvert.SerializeObject(model);
                //var content = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //query parameter is passed after ?
                //route parameters are passed after /
                var response = await client.DeleteAsync($"/Student/DeleteRecord?id={studentId}");  //if query parameter name is 'studentId'
                // var response = await client.DeleteAsync($"/Student/DeleteRecord/{studentId}"); //if route parameter name is 'id'
                //response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseModel>(responseString);
                responseModel = result;
            }
            catch (Exception ex)
            {
                responseModel!.ErrorCode = 8001;
                responseModel.ErrorMessage = ex.Message;
            }

            return responseModel!;
        }

        public Task<ResponseModel<List<string>>> GetRegionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<StudentModel>> GetStudentByIdAsync(Guid studentId)
        {
            var responseModel = new ResponseModel<StudentModel>();
            try
            {
                var tokenResponse = await jWTServices.ReadToken();
                if (!tokenResponse.IsSuccess) throw new Exception($"Error code: {tokenResponse.ErrorCode}, Error message : {tokenResponse.ErrorMessage}");
                var token = tokenResponse.Result;
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);

                //var data = JsonConvert.SerializeObject(model);
                //var content = new StringContent(data, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //query parameter is passed after ?
                //route parameters are passed after /
                var response = await client.GetAsync($"/Student/GetStudentById/{studentId}");
                //response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseModel<StudentModel>>(responseString);
                responseModel = result;
            }
            catch (Exception ex)
            {
                responseModel!.ErrorCode = 8001;
                responseModel.ErrorMessage = ex.Message;
            }

            return responseModel!;
        }

        public async Task<ResponseModel<List<StudentModel>>> GetStudentListAsync()
        {
            var tokenResult = await jWTServices.ReadToken();
            if (!tokenResult.IsSuccess)
            {
                throw new Exception(tokenResult.ErrorCode + ";" + tokenResult.ErrorMessage);
            }
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResult.Result);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("/Student/GetStudentList");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseModel<List<StudentModel>>>(responseString);
            return result;
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

       
    }
}
