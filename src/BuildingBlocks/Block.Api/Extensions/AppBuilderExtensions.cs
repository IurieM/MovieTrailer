using Microsoft.AspNetCore.Builder;
using Block.Api.Middlewares;

namespace Block.Api.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
