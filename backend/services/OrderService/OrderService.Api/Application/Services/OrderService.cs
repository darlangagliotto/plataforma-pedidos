using OrderService.Api.Application.DTOs;
using OrderService.Api.Application.Interfaces;
using OrderService.Api.Domain.Entities;
using OrderService.Api.Infrastructure.Data;

namespace OrderService.Api.Application.Services;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;

    public OrderService(OrderDbContext context) => _context = context;

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request)
    {
        var order = new Order
        {
            Product = request.Product,
            Quantity = request.Quantity,
            CreatedAt = DateTime.UtcNow
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return new OrderResponse
        {
            Id = order.Id,
            Product = order.Product,
            Quantity = order.Quantity,
            CreatedAt = order.CreatedAt
        };
    }
}