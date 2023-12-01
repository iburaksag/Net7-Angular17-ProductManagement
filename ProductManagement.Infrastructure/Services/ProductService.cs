using System;
using ProductManagement.Application.Repositories;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _productRepository.GetAllAsync();

        public async Task<Product> GetByIdAsync(string id) =>
            await _productRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(string categoryId) =>
            await _productRepository.GetProductsByCategoryIdAsync(categoryId);

        public async Task CreateAsync(Product product) =>
            await _productRepository.CreateAsync(product);

        public async Task UpdateAsync(string id, Product product) =>
            await _productRepository.UpdateAsync(id, product);

        public async Task DeleteAsync(string id) =>
            await _productRepository.DeleteAsync(id);
    }
}

