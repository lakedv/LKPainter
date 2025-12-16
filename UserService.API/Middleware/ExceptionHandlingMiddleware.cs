using System.Net;
using System.Text.Json;
using UserService.API.Exceptions;

namespace UserService.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (DomainException ex)
            {
                await HandleDomainException(context, ex);
            } catch (Exception ex) {
                _logger.LogError(ex, "Unhandled exception.");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = "Internal Server Error"
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response)
                    );

            }
        }

        private static async Task HandleDomainException(
            HttpContext context, DomainException ex)
        {
            context.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.BadRequest,
            };

            var response = new
            {
                error = ex.Message
            };

            await context.Response.WriteAsync
            (
                JsonSerializer.Serialize(response)
            );
        }
    }
}
