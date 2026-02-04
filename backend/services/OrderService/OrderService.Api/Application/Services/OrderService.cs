using System.Data.Common;
using System.Text.Json;
using OrderService.Api.Application.DTOs;
using OrderService.Api.Application.Interfaces;
using OrderService.Api.Infrastructure.Data;
using StackExchange.Redis;
using DbOrder = OrderService.Api.Domain.Entities.Order;

namespace OrderService.Api.Application.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;
    private readonly IConnectionMultiplexer _redis;

    public OrderService(OrderDbContext context, IConnectionMultiplexer redis) 
    { 
        _context = context;
        _redis = redis;
    }

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
    {
        var orderEntity = new DbOrder
        {
            Product = request.Product,
            Quantity = request.Quantity,
            CreatedAt = DateTime.UtcNow
        };

        _context.Orders.Add(orderEntity);
        await _context.SaveChangesAsync();

        var response = new OrderResponse
        {
            Id = orderEntity.Id,
            Product = orderEntity.Product,
            Quantity = orderEntity.Quantity,
            CreatedAt = orderEntity.CreatedAt
        };

        // salva no redis
        var dbRedis = _redis.GetDatabase();
        await dbRedis.StringSetAsync(
            GetCacheKey(orderEntity.Id),
            JsonSerializer.Serialize(response),
            TimeSpan.FromMinutes(30)
        );

        return response;
    }

    public async Task<OrderResponse?> GetByIdAsync(int orderId)
    {
        var db = _redis.GetDatabase();
        var cached = await db.StringGetAsync(GetCacheKey(orderId));

        if (cached.HasValue)
        {
            return JsonSerializer.Deserialize<OrderResponse>(cached.ToString());
        }

        // Busca no banco se não estiver no cache
        var orderEntity = await _context.Orders.FindAsync(orderId);
        if (orderEntity == null) return null;

        var response = new OrderResponse
        {
            Id = orderEntity.Id,
            Product = orderEntity.Product,
            Quantity = orderEntity.Quantity,
            CreatedAt = orderEntity.CreatedAt
        };

        // Salva no cache
        await db.StringSetAsync(
            GetCacheKey(orderEntity.Id),
            JsonSerializer.Serialize(response),
            TimeSpan.FromMinutes(30)
        );

        return response;
    }

    private string GetCacheKey(int orderId) => $"order:{orderId}";
}