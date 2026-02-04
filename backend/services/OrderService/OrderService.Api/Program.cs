using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderService.Api.Application.Interfaces;
using OrderService.Api.Application.Services;
using OrderService.Api.Infrastructure.Data;
using System.Text;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

/*
 * ============================
 * SERVICE REGISTRATION
 * ============================
 */

// Adiciona suporte a Controllers (API REST)
builder.Services.AddControllers();

/*
 * Necessário para que o Swagger
 * consiga descobrir endpoints automaticamente
 */
builder.Services.AddEndpointsApiExplorer();

/*
 * Registra o Swagger Generator.
 * Versão simples, sem customização.
 * Customizações (JWT, versões, security)
 * entram em módulos futuros.
 */
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

// EF Core InMemory
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseInMemoryDatabase("OrdersDb");
});

// Dependency Injection
builder.Services.AddScoped<IOrderService, OrderService.Api.Application.Services.OrderService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "auth-service",
            ValidAudience = "order-service",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("super-secret-key-123"))
        };
    });

// Redis
var redisConnection = builder.Configuration.GetValue<string>("Redis:Connection");
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(redisConnection!)
);

var app = builder.Build();

/*
 * ============================
 * HTTP PIPELINE
 * ============================
 */

if (app.Environment.IsDevelopment())
{
    // Gera o swagger.json
    app.UseSwagger();

    // Interface gráfica do Swagger UI
    app.UseSwaggerUI();
}

/*
 * Redireciona HTTP → HTTPS
 */
app.UseHttpsRedirection();

/*
 * Middleware de autorização
 * (JWT será adicionado depois)
 */
app.UseAuthorization();

/*
 * Mapeia os Controllers
 */
app.MapControllers();

app.Urls.Add("http://0.0.0.0:8080");

/*
 * Inicializa a aplicação
 */
app.Run();
