using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductManagement.Application.Repositories;
using ProductManagement.Domain.Common;
using ProductManagement.Infrastructure.Data;

namespace ProductManagement.Infrastructure.Repositories.Common
{
	public class MongoDBBaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoDBBaseRepository(IOptions<MongoDBSettings> dbSettings, string collectionName)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionURI);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _collection.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task UpdateAsync(string id, T entity) =>
            await _collection.ReplaceOneAsync(a => a.Id == id, entity);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(a => a.Id == id);
    }   
}

