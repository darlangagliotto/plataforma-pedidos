using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AuditService.Api.Application.Messaging;

public class OrderCreatedConsumer
{
    private readonly IModel? _channel;
    private readonly bool _isConnected;

    public OrderCreatedConsumer(IConfiguration configuration)
    {
        _isConnected = false;
        
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:Host"],
                AutomaticRecoveryEnabled = true
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(
                exchange: "order.events",
                type: ExchangeType.Fanout,
                durable: true
            );

            _channel.QueueDeclare(
                queue: "audit.order.created",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            _channel.QueueBind(
                queue: "audit.order.created",
                exchange: "order.events",
                routingKey: ""
            );
            
            _isConnected = true;
            Console.WriteLine("✓ OrderCreatedConsumer: Connected to RabbitMQ successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ OrderCreatedConsumer: Failed to connect to RabbitMQ: {ex.Message}");
        }
    }

    public void Start()
    {
        if (!_isConnected || _channel == null)
        {
            Console.WriteLine("✗ OrderCreatedConsumer: Not connected, cannot start listening");
            return;
        }

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (_, ea) =>
        {
            try
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var order = JsonSerializer.Deserialize<OrderCreatedEvent>(json);

                Console.WriteLine("✓ AUDIT EVENT RECEIVED");
                Console.WriteLine($"  OrderId: {order?.Id}");
                Console.WriteLine($"  Product: {order?.Product}");
                Console.WriteLine($"  Quantity: {order?.Quantity}");
                Console.WriteLine($"  CreatedAt: {order?.CreatedAt}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error processing event: {ex.Message}");
            }
        };

        _channel.BasicConsume(
            queue: "audit.order.created",
            autoAck: true,
            consumer: consumer
        );
        
        Console.WriteLine("✓ OrderCreatedConsumer: Started listening for events");
    }
}

