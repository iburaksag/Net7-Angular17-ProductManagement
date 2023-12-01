using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(string categoryId);
    }
}

