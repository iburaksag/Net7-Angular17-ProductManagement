using FluentValidation;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name must be at most 100 characters");

            RuleFor(product => product.Description)
                .MaximumLength(150).WithMessage("Description must be at most 150 characters")
                .Must((product, description) => description?.Contains(product.Name, StringComparison.OrdinalIgnoreCase) ?? true)
                .WithMessage("Description should contain the name of the product");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(product => product.CategoryId)
                .NotEmpty().WithMessage("Category is required");

        }
    }
}

