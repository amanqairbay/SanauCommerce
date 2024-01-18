using Catalog.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FluentValidation;

namespace Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;

/// <summary>
/// Represents a validator.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("{Id} is required.")
            .NotNull();

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(100).WithMessage("{Name} must not exceed 100 characters.");

        RuleFor(command => command.Summary)
            .NotEmpty().WithMessage("{Summary} is required.")
            .NotNull()
            .MaximumLength(100).WithMessage("{Summary} must not exceed 100 characters.");

        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("{Description} is required.")
            .NotNull()
            .MaximumLength(200).WithMessage("{Description} must not exceed 200 characters.");

        RuleFor(command => command.Brand.Id)
           .NotEmpty().WithMessage("{Brand.Id} is required.")
           .NotNull();
        
        RuleFor(command => command.Brand.Name)
           .NotEmpty().WithMessage("{Brand.Name} is required.")
           .NotNull()
           .MaximumLength(200).WithMessage("{Brand.Name} must not exceed 200 characters.");

        RuleFor(command => command.Type.Id)
            .NotEmpty().WithMessage("{Type.Id} is required.")
            .NotNull();
        
        RuleFor(command => command.Type.Name)
           .NotEmpty().WithMessage("{Type.Name} is required.")
           .NotNull()
           .MaximumLength(200).WithMessage("{Type.Name} must not exceed 200 characters.");

        RuleForEach(command => command.Images)
            .ChildRules( image => 
            {
                image.RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("{Id} is required.")
                    .NotNull();
                image.RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("{Name} is required.")
                    .NotNull()
                    .MaximumLength(200).WithMessage("{Name} must not exceed 200 characters.");
                image.RuleFor(x => x.ProductId)
                    .NotEmpty().WithMessage("{ProductId} is required.")
                    .NotNull();
            });
        
        RuleFor(command => command.Price)
            .NotEmpty().WithMessage("{Price} is required.")
            .GreaterThan(0)
            .NotNull();
    }
}