using GbgGoodDeeds.Application.Interfaces;
using GbgGoodDeeds.Domain.Models;
using GbgGoodDeeds.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GbgGoodDeeds.Infrastructure.Repositories;

public class MongoGoodDeedRepository : IGoodDeedRepository
{
    private readonly IMongoCollection<GoodDeed> _collection;

    public MongoGoodDeedRepository(IOptions<MongoDbOptions> options)
    {
        var config = options.Value;
        var client = new MongoClient(config.GetConnectionString());
        var database = client.GetDatabase(config.Database);
        _collection = database.GetCollection<GoodDeed>(config.Collection);
    }

    public async Task<IEnumerable<GoodDeed>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<GoodDeed?> GetByIdAsync(string id)
    {
        return await _collection.Find(d => d.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(GoodDeed deed)
    {
        await _collection.InsertOneAsync(deed);
    }

    public async Task<bool> MarkAsCompletedAsync(string id)
    {
        var update = Builders<GoodDeed>.Update.Set(d => d.IsCompleted, true);
        var result = await _collection.UpdateOneAsync(
            d => d.Id == id, update);
        return result.ModifiedCount > 0;
    }
}
