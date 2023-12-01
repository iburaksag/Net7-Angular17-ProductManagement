using System;
using FluentValidation;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(category => category.Description)
                .NotEmpty().WithMessage("Description is required");
        }
    }
}
