using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SimpleRegister.Infrastructure.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SimpleRegister.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(
            ILogger<GlobalExceptionMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (IdentityException exception)
            {
                context.Response.ContentType = "application/text";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(exception.Message);
            }
            catch (EmailException exception)
            {
                LogException(exception);

                context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
            }
            catch (Exception exception)
            {
                LogException(exception);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }

        private void LogException(Exception exception)
        {
            _logger.LogError($"{exception.GetType()}: {exception.Message}");
            _logger.LogError(exception.StackTrace);
        }
    }
}
