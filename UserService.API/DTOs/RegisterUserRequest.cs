namespace UserService.API.DTOs
{
    public class RegisterUserRequest
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
