using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.API.DTOs;
using UserService.API.Exceptions;
using UserService.API.Services.Interfaces;
using UserService.Models;


namespace UserService.API.Services
{
    public class UserServiceImpl : IUserService, IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public UserServiceImpl(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        private string GenerateJwtToken(User user, IList<string> roles)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var jwtKey = jwtSettings["Key"]!;
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiresInMinutes = int.Parse(jwtSettings["ExpiresInMinutes"]!);

            var claims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!)
            };
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var signingKey = new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(jwtKey)
                );

            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: creds
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> RegisterAsync(string email, string userName, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded) 
            {
                var errors = string.Join(" | ", result.Errors.Select(e => e.Description));
                throw new DomainException(errors);
            }
            await _userManager.AddToRoleAsync(user, "User");

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return _userManager.Users.ToList();
        }

        public async Task<AuthResponse> LoginAsync(LoginUserRequest request) 
        {
            var user = await _userManager.FindByNameAsync(request.UserNameOrEmail)
                ?? await _userManager.FindByEmailAsync(request.UserNameOrEmail);

            if (user == null)
                throw new UnauthorizedException("Invalid UserName or Email");

            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordValid)
                throw new UnauthorizedException("Invalid Password.");

            var roles = await _userManager.GetRolesAsync(user);

            var token = GenerateJwtToken(user, roles);

            var jwtSettings = _configuration.GetSection("Jwt");
            var expiresAt = DateTime.UtcNow.AddMinutes(
                int.Parse(jwtSettings["ExpiresInMinutes"]!)
                );

            return new AuthResponse
            { 
            User = new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                CreatedAt = user.CreatedAt,
            },
                Token = token,
                ExpiresAt = expiresAt
            };

        }

        public async Task<UserResponse> GetCurrentUserAsync(ClaimsPrincipal principal)
        {
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedException("Invalid Token");

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new UnauthorizedException("User not Found");

            return new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                CreatedAt= user.CreatedAt,
            };
        }
    }
}
