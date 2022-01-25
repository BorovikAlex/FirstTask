using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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

        public TimeTrackingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var watch = new Stopwatch();
            watch.Start();

            string requestTime = DateTime.UtcNow.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);

            httpContext.Response.OnStarting(() => {
       
                watch.Stop();

                string responseTime = DateTime.UtcNow.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture);

                Debug.WriteLine($"Request time: {requestTime} {System.Environment.NewLine}" +
                $"Response time: {responseTime} {System.Environment.NewLine}" +
                $"Time between request and response: {watch.ElapsedMilliseconds.ToString()+ "ms"} {System.Environment.NewLine} " +
                $"");

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
