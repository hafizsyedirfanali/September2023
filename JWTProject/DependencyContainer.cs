using JWTProject.Repositories;
using JWTProject.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace JWTProject
{
    public static class DependencyContainer
    {
        public static void RegisterJWTService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IJWTServices, JWTRepository>();
        }
    }
}
