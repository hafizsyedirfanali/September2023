
using JWTProject.Models;
using JWTProject.ResponseModels;
/*using Microsoft.AspNet.Identity.EntityFramework;*/
using Newtonsoft.Json;

namespace JWTProject.Services
{
    public interface IJWTServices
    {
        Task<ResponseModel<string>> GetToken();//Gets token from server
        Task<ResponseModel<string>> ReadToken();
        Task<ResponseModel<bool>> IsTokenExpired(string token);//Checks if token is expired from server side

        Task<ResponseModel<string>> SaveToken(string token);
    }
}
