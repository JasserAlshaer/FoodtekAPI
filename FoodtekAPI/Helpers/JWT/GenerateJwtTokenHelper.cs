using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using FoodtekAPI.Models;

namespace FoodtekAPI.Helpers.JWT
{
    public class GenerateJwtTokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public GenerateJwtTokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:IssuerIP"],
                audience: _configuration["JWT:AudienceIP"],
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
