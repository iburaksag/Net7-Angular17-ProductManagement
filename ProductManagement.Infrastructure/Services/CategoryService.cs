using System;
using ProductManagement.Application.Repositories;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _categoryRepository.GetAllAsync();

        public async Task<Category> GetByIdAsync(string id) =>
            await _categoryRepository.GetByIdAsync(id);

        public async Task CreateAsync(Category category) =>
            await _categoryRepository.CreateAsync(category);

        public async Task UpdateAsync(string id, Category category) =>
            await _categoryRepository.UpdateAsync(id, category);

        public async Task DeleteAsync(string id) =>
            await _categoryRepository.DeleteAsync(id);
    }
}

