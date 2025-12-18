using FluentValidation;
using CatalogService.API.DTOs;

namespace CatalogService.API.Validators
{
    public class ModelCreateRequestValidator 
        : AbstractValidator<ModelCreateRequest>
    {
        public ModelCreateRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Faction)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.BaseSvgPath)
                .NotEmpty();
        }
    }
}
