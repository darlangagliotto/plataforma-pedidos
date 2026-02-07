using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace OrderService.Api.Application.Messaging
{
    public class RabbitMqEventPublisher : IEventPublisher
    {
        private readonly IModel? _channel;
        private readonly bool _isConnected;

        public RabbitMqEventPublisher(IConfiguration configuration)
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
                
                _isConnected = true;
                Console.WriteLine("✓ RabbitMqEventPublisher: Connected successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ RabbitMqEventPublisher: Connection failed: {ex.Message}");
            }
        }

        public Task PublishAsync<T>(T @event)
        {
            if (!_isConnected || _channel == null)
            {
                Console.WriteLine($"✗ RabbitMqEventPublisher: Not connected. Event not published: {typeof(T).Name}");
                return Task.CompletedTask;
            }

            try
            {
                var body = Encoding.UTF8.GetBytes(
                    JsonSerializer.Serialize(@event)
                );

                _channel.BasicPublish(
                    exchange: "order.events",
                    routingKey: "",
                    basicProperties: null,
                    body: body
                );
                
                Console.WriteLine($"✓ RabbitMqEventPublisher: Event published: {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ RabbitMqEventPublisher: Failed to publish event: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}