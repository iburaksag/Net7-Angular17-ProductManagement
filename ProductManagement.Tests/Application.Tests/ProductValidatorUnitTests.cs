using System;
using ProductManagement.Application.Validations;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Tests
{
    [TestFixture]
    public class ProductValidatorUnitTests
    {
        [Test]
        public void Validate_ProductWithAtMostOneHundredNameLength_ShouldHaveValidationError()
        {
            var product = new Product { Name = new string('A', 101), Description = "Valid Description", Price = 10, CategoryId = "CategoryId" };
            var validator = new ProductValidator();

            var result = validator.Validate(product);

            StringAssert.Contains("Name must be at most 100 characters", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_ProductWithAtMostOneHundredFiftyDescriptionLength_ShouldHaveValidationError()
        {
            var product = new Product { Name = "Valid Name", Description = new string('A', 151), Price = 10, CategoryId = "CategoryId" };
            var validator = new ProductValidator();

            var result = validator.Validate(product);

            StringAssert.Contains("Description must be at most 150 characters", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_ProductWithDescriptionNotContainingName_ShouldHaveValidationError()
        {
            var product = new Product { Name = "ValidName", Description = "InvalidDescription", Price = 10, CategoryId = "CategoryId" };
            var validator = new ProductValidator();

            var result = validator.Validate(product);

            StringAssert.Contains("Description should contain the name of the product", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_ProductWithDescriptionContainingName_ShouldNotHaveValidationError()
        {
            var product = new Product { Name = "ValidName", Description = "Description with ValidName", Price = 10, CategoryId = "CategoryId" };
            var validator = new ProductValidator();

            var result = validator.Validate(product);

            Assert.That(result.Errors, Is.Empty);
        }


        [Test]
        public void Validate_ProductWithEmptyPrice_ShouldHaveValidationError()
        {
            var product = new Product { Name = "Valid Name", Description = "Valid Name Valid Description", Price = 0, CategoryId = "CategoryId" };
            var validator = new ProductValidator();

            var result = validator.Validate(product);

            StringAssert.Contains("Price is required", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_ProductWithNegativePrice_ShouldHaveValidationError()
        {
            var product = new Product { Name = "Valid Name", Description = "Valid Name Valid Description", Price = -10, CategoryId = "CategoryId" };
            var validator = new ProductValidator();

            var result = validator.Validate(product);

            StringAssert.Contains("Price must be greater than 0", result.Errors[0].ErrorMessage);
        }

        [Test]
        public void Validate_ProductWithEmptyCategoryId_ShouldHaveValidationError()
        {
            var product = new Product { Name = "Valid Name", Description = "Valid Name Valid Description", Price = 10, CategoryId = "" };
            var validator = new ProductValidator();

            var result = validator.Validate(product);

            StringAssert.Contains("Category is required", result.Errors[0].ErrorMessage);
        }

    }
}

