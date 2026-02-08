using OrderService.Api.Application.DTOs;
using OrderService.Api.Application.Interfaces;
using OrderService.Api.Infrastructure.Data;
using OrderService.Api.Application.Events;
using OrderService.Api.Application.Messaging;
using DbOrder = OrderService.Api.Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Api.Application.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;
    private readonly ICacheService _redis;

    private readonly IEventPublisher _publisher;

    public OrderService(OrderDbContext context, ICacheService redis, IEventPublisher publisher) 
    { 
        _context = context;
        _redis = redis;
        _publisher = publisher;
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

         var response = MapToResponse(orderEntity);

        // salva no redis        
        await _redis.SetAsync(
            GetCacheKey(orderEntity.Id),
            response,
            TimeSpan.FromMinutes(30)
        );

        // evento de dominio

        await _publisher.PublishAsync(
            new OrderCreatedEvent(
                orderEntity.Id,
                orderEntity.Product,
                orderEntity.Quantity,
                orderEntity.CreatedAt
            )
        );

        return response;
    }

    public async Task<IEnumerable<OrderResponse>> GetAllAsync()
    {
        var orders = await _context.Orders
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync();

        return orders.Select(MapToResponse);
    }

    public async Task<OrderResponse?> GetByIdAsync(int orderId)
    {
        var cached = await _redis.GetAsync<OrderResponse>(GetCacheKey(orderId));

        if (cached != null)
        {
            return cached;
        }

        // Busca no banco se não estiver no cache
        var orderEntity = await _context.Orders.FindAsync(orderId);
        if (orderEntity == null) 
        {
            return null;
        }

        var response = MapToResponse(orderEntity);

        // Salva no cache
        await _redis.SetAsync(
            GetCacheKey(orderEntity.Id),
            response,
            TimeSpan.FromMinutes(30)
        );

        return response;
    }

    private static OrderResponse MapToResponse(DbOrder order) =>
        new()
        {
          Id = order.Id,
          Product = order.Product,
          Quantity = order.Quantity,
          CreatedAt = order.CreatedAt  
        };

    private static string GetCacheKey(int orderId) => $"order:{orderId}";
}