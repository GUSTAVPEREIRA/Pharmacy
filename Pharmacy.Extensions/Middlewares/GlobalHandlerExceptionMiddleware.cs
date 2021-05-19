using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pharmacy.Extensions.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Pharmacy.Extensions.Middlewares
{
    class GlobalHandlerExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalHandlerExceptionMiddleware> logger;

        public GlobalHandlerExceptionMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError($"Unexpected error: {ex.Message}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is APIException apiException)
            {
                context.Response.StatusCode = (int)apiException.StatusCode;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var message = exception.Message;

            var json = new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}
