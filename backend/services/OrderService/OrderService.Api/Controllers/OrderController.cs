using System.Text;
using System.Text.Json;
using OrderService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest newOrder)
        {
            var createdOrder = new
            {
                Id = Random.Shared.Next(1000, 9999),
                Product = newOrder.Product,
                Quantity = newOrder.Quantity,
                CreatedAt = DateTime.UtcNow
            };

            await _httpClient.PostAsJsonAsync(
                "http://localhost:5103/api/webhook",
                createdOrder
            );

            return Created(string.Empty, createdOrder);
        }
    }
}