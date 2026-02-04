namespace OrderService.Api.Application.DTOs;

public class CreateOrderRequest
{
    public string Product {get; set; } = string.Empty;
    public int Quantity {get; set; }
}
