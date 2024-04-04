using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MVCStartApp.Repositories;
using MVCStartApp.Models.Db;
using Microsoft.Extensions.DependencyInjection;

namespace MVCStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next )
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRequestRepository repo)
        {
            await repo.WriteRequest(new Request
            {
                Date = DateTime.Now,
                Id = Guid.NewGuid(),
                Url = "http://" + context.Request.Host.Value + context.Request.Path
            });
            await _next.Invoke(context);
        }
    }
}
