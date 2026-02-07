namespace AuditService.Api.Application.Messaging;

public record OrderCreatedEvent(
    int Id,
    string Product,
    int Quantity,
    DateTime CreatedAt        
);