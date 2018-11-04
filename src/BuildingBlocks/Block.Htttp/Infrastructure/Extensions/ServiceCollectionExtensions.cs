using Microsoft.Extensions.DependencyInjection;

namespace Block.Http.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHttpServices(this IServiceCollection services)
        {
            services.AddScoped<IHttpClient, StandardHttpClient>();
        }
    }
}
