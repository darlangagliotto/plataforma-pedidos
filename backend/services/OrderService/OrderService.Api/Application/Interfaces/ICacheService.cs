using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Application.Interfaces
{
    public interface ICacheService
    {
        Task SetAsync<T>(string key, T value, TimeSpan? expriry = null);
        Task<T?> GetAsync<T>(string key);
        Task RemoveAsync(string key);
    }
}