using ProductManagement.API.DTOs.AuthDtos;

using ProductManagement.API.Models;

namespace ProductManagement.API.Services.Interface
{
    public interface IAuthService
    {
        Task<AuthenticationResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthenticationResponseDto> LoginAsync(LoginDto loginDto);
    }
}
