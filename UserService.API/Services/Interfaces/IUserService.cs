using System.Security.Claims;
using UserService.API.DTOs;
using UserService.Models;

namespace UserService.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string email, string userName, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<UserResponse> GetCurrentUserAsync(ClaimsPrincipal user);
    }
}
