using System.Data;

namespace OrderService.Api.Application.Events;

public record OrderCreatedEvent(
    int Id,
    string Product,
    int Quantity,
    DateTime CreatedAt
);