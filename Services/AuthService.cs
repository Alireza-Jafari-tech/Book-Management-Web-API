using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using apiApp.Interfaces;
using apiApp.DTOs;

namespace apiApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(LoginDto user)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes
                (_config["Jwt:key"]));

            var creds = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256);

            var duration = Convert.ToDouble(_config["Jwt:DurationInMinutes"]);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                signingCredentials: creds,
                expires: DateTime.UtcNow
                    .AddMinutes(duration)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string? Login(LoginDto user)
        {
            // Simulate login validation logic
            if (user.Name == "admin" && user.Password == "password")
            {
                var token = GenerateToken(user);
                return token;
            }

            return null;
        }
    }
}