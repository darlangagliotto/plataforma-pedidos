using Microsoft.AspNetCore.Mvc;
using OrderService.Api.Application.DTOs;
using OrderService.Api.Application.Interfaces;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => _orderService = orderService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest newOrder)
        {
            var result = await _orderService.CreateAsync(newOrder);
            return CreatedAtAction(nameof(Create), result);
        }
    }
}