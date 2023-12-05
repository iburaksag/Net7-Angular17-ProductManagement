using System;
using Microsoft.Extensions.Options;
using ProductManagement.Application.Repositories;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;
using ProductManagement.Infrastructure.Repositories.Common;

namespace ProductManagement.Infrastructure.Repositories
{
    public class CategoryRepository : MongoDBBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IOptions<MongoDBSettings> dbSettings)
            : base(dbSettings, "Categories")
        {
        }

        //Extra methods specific for Category

    }
}

