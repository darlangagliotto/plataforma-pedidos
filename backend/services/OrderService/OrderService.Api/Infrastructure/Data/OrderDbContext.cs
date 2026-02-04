using Microsoft.EntityFrameworkCore;
using OrderService.Api.Domain.Entities;

namespace OrderService.Api.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {        
    }

    public DbSet<Order> Orders => Set<Order>();
}