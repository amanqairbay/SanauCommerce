using FluentValidation;

namespace Catalog.Application.Features.Photos.Commands.UpdatePhoto;

/// <summary>
/// Represents a photo validator.
/// </summary>
public class UpdatePhotoCommandValidator : AbstractValidator<UpdatePhotoCommand>
{
    public UpdatePhotoCommandValidator()
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