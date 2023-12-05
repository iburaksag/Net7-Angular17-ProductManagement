using System;
using ProductManagement.Application.Validations;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Tests
{
    [TestFixture]
    public class CategoryValidatorUnitTests
	{
        [Test]
        public void Validate_CategoryWithEmptyName_ShouldHaveValidationError()
        {
            var category = new Category { Name = "", Description = "Valid Description" };
            var validator = new CategoryValidator();

            var result = validator.Validate(category);

            Assert.That(result.Errors, Has.Count.EqualTo(1));
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Name is required"));
        }

        [Test]
        public void Validate_CategoryWithEmptyDescription_ShouldHaveValidationError()
        {
            var category = new Category { Name = "Valid Name", Description = "" };
            var validator = new CategoryValidator();

            var result = validator.Validate(category);

            Assert.That(result.Errors, Has.Count.EqualTo(1));
            Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Description is required"));
        }
    }
}

