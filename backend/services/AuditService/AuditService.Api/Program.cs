using AuditService.Api.Application.Messaging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<OrderCreatedConsumer>();

var app = builder.Build();

var consumer = app.Services.GetRequiredService<OrderCreatedConsumer>();
consumer.Start();

app.Run();