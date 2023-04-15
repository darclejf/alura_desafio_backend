using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.WebAPI.Extensions;
using System.Text.Json;

namespace AluraChallenge.Adopet.WebAPI.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var exceptionResult = JsonSerializer.Serialize(new ErrorResponse { Messages = new List<string> { exception.Message } });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.GetHttpStatusCode();
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
