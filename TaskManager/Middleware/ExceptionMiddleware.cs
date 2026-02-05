using System.Net;
using System.Text.Json;

namespace TaskManager.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("🔥 EXCEPTION:");
                Console.WriteLine(ex.ToString());

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = ex.Message,
                    stack = ex.StackTrace
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }

    }
}
