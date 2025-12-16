using FluentValidation;
using UserService.API.DTOs;

namespace UserService.API.Validators
{
    public class LoginUserRequestValidator 
        : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator() 
        {
            RuleFor(x => x.UserNameOrEmail).NotEmpty();

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
