using FluentValidation;

namespace CatalogService.API.Validators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .Must(id => id != Guid.Empty)
                .WithMessage("Invalid Id");
        }
    }
}
