using FluentValidation;

namespace Catalog.Application.Features.Photos.Commands.CreatePhoto;

/// <summary>
/// Represents a validator.
/// </summary>
public class CreatePhotoCommandValidator : AbstractValidator<CreatePhotoCommand>
{
    public CreatePhotoCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters.");

        RuleFor(p => p.IsMain)
            .NotEmpty().WithMessage("{IsMain} is required.")
            .NotNull();
    }
}