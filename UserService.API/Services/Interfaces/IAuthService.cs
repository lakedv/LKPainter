using UserService.API.DTOs;

namespace UserService.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginUserRequest request);
    }
}
