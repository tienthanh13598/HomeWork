using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Hw.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var request = context.Request;
            String url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
            
            String name = context.Request.Query["name"];
            if (!String.IsNullOrWhiteSpace(name)) {
                context.Request.Headers.Add("time", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            }

            Console.WriteLine($"Current url: {url}");
            Console.WriteLine($"Elasped time: {sw.ElapsedTicks.ToString()} ticks");

            await _next(context);
        }
    }

    public static class CustomMiddlewareExtension {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}