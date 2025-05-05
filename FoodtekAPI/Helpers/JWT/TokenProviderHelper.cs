using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System;
using FoodtekAPI.interfaces;
using FoodtekAPI.Models;

namespace FoodtekAPI.Helpers.JWT

{
    public class TokenProviderHelper: ITokenProvider
    {
        private readonly IConfiguration _configuration;

        public TokenProviderHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
            string secretKey = _configuration["Jwt:Secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("email_verified", user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Jwt:ExpirationInMinutes")),
                SigningCredentials = credentials,
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
