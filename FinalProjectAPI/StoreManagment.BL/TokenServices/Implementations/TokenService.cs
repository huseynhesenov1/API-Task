using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreManagment.BL.TokenServices.Abstractions;
using StoreManagment.Core.Entities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreManagment.BL.TokenServices.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(AppUser appUser, IList<string> roles)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("FirstName", appUser.FirstName),
                new Claim(ClaimTypes.Name,appUser.UserName),
                new Claim(ClaimTypes.NameIdentifier,appUser.Id)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Securitykey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims, issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"], signingCredentials: signingCredentials, expires: DateTime.UtcNow.AddMinutes(10));
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
