using FluentValidation;

namespace Catalog.Application.Features.ProductImageFeatures.Commands.UpdateProductImage;

public class UpdateProductImageCommandValidator : AbstractValidator<UpdateProductImageCommand>
{
    public UpdateProductImageCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("{Id} is required.")
            .NotNull();

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("{Name} must not exceed 100 characters.");

        RuleFor(command => command.ProductId)
            .NotEmpty().WithMessage("{ProductId} is required.")
            .NotNull();

        RuleFor(command => command.IsMain)
            .NotEmpty().WithMessage("{IsMain} is required.")
            .NotNull();
    }
}