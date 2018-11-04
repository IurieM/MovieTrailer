using Block.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Block.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory
                 .CreateLogger<ExceptionHandlerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (AppException ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Internal_Server_Error");
            }
        }
    }
}
