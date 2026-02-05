using StackExchange.Redis;
using System.Text.Json;
using OrderService.Api.Application.Interfaces;

namespace OrderService.Api.Application.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var json = JsonSerializer.Serialize(value);
        if (expiry.HasValue)
        {
            await _database.StringSetAsync(key, json, expiry.Value);
        }
        else
        {
            await _database.StringSetAsync(key, json);
        }
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _database.StringGetAsync(key);
        if (value.IsNullOrEmpty)
        {
             return default;
        }
        return JsonSerializer.Deserialize<T>(value.ToString());
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }
}
