using FluentValidation;
using CatalogService.API.DTOs;

namespace CatalogService.API.Validators
{
    public class CreateModelPartRequestValidator : AbstractValidator<CreateModelPartRequest>
    {
        public CreateModelPartRequestValidator()
        {
            RuleFor(x => x.ModelId).NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Type)
                .IsInEnum();

            RuleFor(x => x.SvgPath)
                .NotEmpty();

            RuleFor(x => x.LayerOrder)
                .GreaterThanOrEqualTo(0);
        }

    }
}
