using Microsoft.IdentityModel.Tokens;
using DbProjectAsync.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DbProjectAsync.Repositories
{
    public class JWTRepository : IJWTServices
    {
        private readonly IConfiguration configuration;
        public JWTRepository(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public string GenerateToken()
        {
            var keySecret = configuration.GetSection("JwtSettings:Key").Value!;
            var issuer = configuration.GetSection("JwtSettings:Issuer").Value!;
            var audience = configuration.GetSection("JwtSettings:Audience").Value!;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keySecret));

            //var roles = new[] { "Admin", "Editor" };
            var roles = new[] { "Admin"};
            //var policies = new[] { "AdminPolicy", "EditorPolicy" };
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
            //var policyClaims = policies.Select(policy => new Claim("policy", policy));
            var allClaims = new List<Claim>();
            allClaims.AddRange(roleClaims);//here roles are added as claim
            //allClaims.AddRange(policyClaims);//here policies are added as claim


            var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: allClaims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
