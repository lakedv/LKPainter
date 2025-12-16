namespace UserService.API.DTOs
{
    public class LoginUserRequest
    {
        public string UserNameOrEmail { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
