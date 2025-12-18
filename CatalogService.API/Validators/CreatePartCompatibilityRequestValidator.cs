using FluentValidation;
using CatalogService.API.DTOs;

namespace CatalogService.API.Validators
{
    public class CreatePartCompatibilityRequestValidator : AbstractValidator<CreatePartCompatibilityRequest>
    {
        public CreatePartCompatibilityRequestValidator() 
        {
            RuleFor(x => x.SourcePartId).NotEmpty();

            RuleFor(x => x.CompatibleWithPartId).NotEmpty();
        }
    }
}
