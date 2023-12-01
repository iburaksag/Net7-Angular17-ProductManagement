using System;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Services
{
	public interface IProductService
	{
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(string id);
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(string categoryId);
        Task CreateAsync(Product product);
        Task UpdateAsync(string id, Product product);
        Task DeleteAsync(string id);
    }
}

