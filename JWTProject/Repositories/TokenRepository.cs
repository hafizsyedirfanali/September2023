using JWTProject.Models;
using JWTProject.ResponseModels;
using JWTProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace JWTProject.Repositories
{
    public class JWTRepository : IJWTServices
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SignInManager<IdentityUser> signInManager;
        public JWTRepository(IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, SignInManager<IdentityUser> signInManager)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.signInManager = signInManager;
        }


        private bool _IsTokenExpired(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                // Read the token without verifying it to get its claims
                JwtSecurityToken jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    // Token couldn't be parsed
                    return true;
                }

                // Check if the token has an expiration time
                if (jwtToken.ValidTo != null)
                {
                    // Compare with the current time
                    return jwtToken.ValidTo < DateTime.UtcNow;
                }

                // Token does not have an expiration time
                return true;
            }
            catch (Exception)
            {
                // Exception handling (token couldn't be read or other issues)
                return true;
            }
        }

        public async Task<ResponseModel<bool>> IsTokenExpired(string token)
        {
            var responseModel = new ResponseModel<bool>();
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                responseModel.Result = _IsTokenExpired(token);
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                // Exception handling (token couldn't be read or other issues)
                responseModel.Result = true;
                responseModel.IsSuccess = false;
                responseModel.ErrorMessage = ex.Message;
                responseModel.ErrorCode = 90000;
                   
            }
            return responseModel;
        }


        public async Task<ResponseModel<string>> GetToken()
        {
            var responseModel = new ResponseModel<string>();
            try
            {
                var cookieResponse = httpContextAccessor.HttpContext.Response;
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(configuration.GetSection("EndPointUrl").Value);
                
                string? requestUrl = "Home/GetToken";

                client.DefaultRequestHeaders.Add("password", "Abcd@1234");
                //var content = new StringContent(request, Encoding.UTF8, "application/json");
                var response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();

                TokenObjectResponseModel? tokenObj = JsonConvert.DeserializeObject<TokenObjectResponseModel>(responseString);
                if (tokenObj is not null)
                {
                    var token = tokenObj.Token;
                    responseModel.Result = token;
                    responseModel.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorMessage = ex.Message;
                responseModel.ErrorCode = 5000;
            }
            return responseModel;
        }

        public async Task<ResponseModel<string>> ReadToken()
        {
            var responseModel = new ResponseModel<string>();
            try
            {
                var token = this.httpContextAccessor.HttpContext!.Request.Cookies["token"];
                if (token is not null && !_IsTokenExpired(token))
                {
                    responseModel.Result = token;
                    responseModel.IsSuccess = true;
                }
                else
                {
                    await signInManager.SignOutAsync();
                }
            }
            catch (Exception ex)
            {
                responseModel.ErrorMessage = ex.Message;
                responseModel.ErrorCode = 9000;
            }
            return responseModel;
        }

        public async Task<ResponseModel<string>> SaveToken(string token)
        {
            var responseModel = new ResponseModel<string>();
            try
            {
                if (token == null)
                {
                    responseModel.ErrorCode = 15000;
                    responseModel.ErrorMessage = "Invalid Token";
                    responseModel.IsSuccess = false;
                }
                var cookieResponse = httpContextAccessor.HttpContext.Response;
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                cookieResponse.Cookies.Append("token", token, option);
                responseModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                responseModel.ErrorMessage = ex.Message;
                responseModel.ErrorCode = 9000;
            }
            return responseModel;
        }

    }
}
