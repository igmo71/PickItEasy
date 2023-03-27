using FluentValidation;
using PickItEasy.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace PickItEasy.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case EntityNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            if(string.IsNullOrEmpty(result)) 
                result = JsonSerializer.Serialize(new { error = exception.Message });
            return context.Response.WriteAsync(result);
        }
    }
}
