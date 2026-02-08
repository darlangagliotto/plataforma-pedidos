using OrderService.Api.Application.DTOs;

namespace OrderService.Api.Application.Interfaces;

public interface IOrderService
{
    Task<OrderResponse> CreateAsync(CreateOrderRequest request);
    Task<OrderResponse?> GetByIdAsync(int orderId);
    Task<IEnumerable<OrderResponse>> GetAllAsync();
}