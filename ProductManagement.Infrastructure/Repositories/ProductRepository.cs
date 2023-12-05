using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagement.Application.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;
using ProductManagement.Infrastructure.Repositories.Common;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository : MongoDBBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IOptions<MongoDBSettings> dbSettings) : base(dbSettings, "Products")
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(string categoryId) =>
                await _collection.Find(a => a.CategoryId == categoryId).ToListAsync();
    }
}

