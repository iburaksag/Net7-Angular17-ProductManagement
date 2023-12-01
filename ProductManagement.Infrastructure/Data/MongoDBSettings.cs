using System;
namespace ProductManagement.Infrastructure.Data
{
	public class MongoDBSettings
	{
        public string? ConnectionURI { get; set; }
        public string? DatabaseName { get; set; }
        public string? ProductsCollectionName { get; set; }
        public string? CategoriesCollectionName { get; set; }
    }
}

