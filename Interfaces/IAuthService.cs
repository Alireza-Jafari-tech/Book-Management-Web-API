using apiApp.DTOs;

namespace apiApp.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(LoginDto user);
        string? Login(LoginDto user);
    }
}