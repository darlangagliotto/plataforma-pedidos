using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Application.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event);
    }
}