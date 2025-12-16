namespace UserService.API.DTOs
{
    public class AuthResponse
    {
        public UserResponse User { get; set; } = default!;
        public string Token { get; set; } = default!;
        public DateTime ExpiresAt { get; set; }
    }
}
