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
        public readonly IModel _channel;

        public RabbitMqEventPublisher(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:Host"]
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(
                exchange: "order.events",
                type: ExchangeType.Fanout,
                durable: true
            );            
        }

        public Task PublishAsync<T>(T @event)
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

            return Task.CompletedTask;
        }
    }
}