using System;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Services
{
	public interface ICategoryService
	{
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(string id);
        Task CreateAsync(Category category);
        Task UpdateAsync(string id, Category category);
        Task DeleteAsync(string id);
    }
}

