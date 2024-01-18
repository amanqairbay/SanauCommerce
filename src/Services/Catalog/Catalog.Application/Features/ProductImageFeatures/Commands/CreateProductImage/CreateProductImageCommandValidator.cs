using FluentValidation;

namespace Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;

/// <summary>
/// Represents a validator.
/// </summary>
public class CreateProductImageCommandValidator : AbstractValidator<CreateProductImageCommand>
{
    public CreateProductImageCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters.");

        RuleFor(p => p.ProductId)
           .NotEmpty().WithMessage("{ProductId} is required.")
           .NotNull();

        RuleFor(p => p.IsMain)
            .NotEmpty().WithMessage("{IsMain} is required.")
            .NotNull();
    }
}