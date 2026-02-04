using StackExchange.Redis;
using System.Text.Json;

namespace OrderService.Api.Application.Services;

public class RedisCacheService
{
    private readonly IDatabase _database;

    public RedisCacheService(string connectionString)
    {
        var redis = ConnectionMultiplexer.Connect(connectionString);
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
