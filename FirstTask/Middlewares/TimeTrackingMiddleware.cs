using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace FirstTask.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TimeTrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TimeTrackingMiddleware> _logger;

        public TimeTrackingMiddleware(RequestDelegate next, ILogger<TimeTrackingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var watch = new Stopwatch();
            watch.Start();

            string requestTime = DateTime.UtcNow.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);

            httpContext.Response.OnStarting(() => {
       
                watch.Stop();

                string responseTime = DateTime.UtcNow.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);

                _logger.LogInformation("Time between request and response: {watch.ElapsedMilliseconds.ToString()} ms", watch.ElapsedMilliseconds.ToString());

                return Task.CompletedTask; 
            });
             
             await this._next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseTimeTrackingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeTrackingMiddleware>();
        }
    }
}
