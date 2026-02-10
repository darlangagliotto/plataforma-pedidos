using Xunit;
using Moq;
using FluentAssertions;
using System.Threading.Tasks;
using OrderService.Api.Application.Interfaces;
using OrderService.Api.Application.DTOs;
using OrderService.Api.Application.Messaging;
using OrderService.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderService.UnitTests;

public class OrderServiceTest
{
    [Theory]
    [InlineData("Produto 1", 1)]
    [InlineData("Produto 2", 5)]
    public async Task CreateOrder_Should_Create_Order_When_Valid(string product, int quantity)
    {
        //Arrange
        var request = new CreateOrderRequest
        {
            Product = product,
            Quantity = quantity
        };

        var redisMock = new Mock<ICacheService>();
        var publisherMock = new Mock<IEventPublisher>();

        var options = new DbContextOptionsBuilder<OrderDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // banco temporário único por teste
            .Options;

        var context = new OrderDbContext(options);
        var service = new Api.Application.Services.OrderService(context, redisMock.Object, publisherMock.Object);

        // Act
        var result = await service.CreateAsync(request);

        //Assert
        result.Product.Should().Be(product);
        result.Quantity.Should().Be(quantity);
        result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public async Task GetById_Should_Return_Order_From_Cache_If_Exists()
    {
        var orderId = 1;

        // Arrange        
        var cacheOrder = new OrderResponse
        {
            Id = orderId,
            Product = "Produto cache",
            Quantity = 3,
            CreatedAt = DateTime.UtcNow
        };

        var redisMock = new Mock<ICacheService>();
        redisMock.Setup(r => r.GetAsync<OrderResponse>(It.IsAny<string>()))
            .ReturnsAsync(cacheOrder);

        var publisherMock = new Mock<IEventPublisher>();

         var options = new DbContextOptionsBuilder<OrderDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())   
            .Options;

        var context = new OrderDbContext(options);
        var service = new Api.Application.Services.OrderService(context, redisMock.Object, publisherMock.Object);

        //Act
        var result = await service.GetByIdAsync(orderId);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(orderId);
        result.Product.Should().Be("Produto cache");

        redisMock.Verify(r => r.GetAsync<OrderResponse>(It.IsAny<string>()));
    }
}
