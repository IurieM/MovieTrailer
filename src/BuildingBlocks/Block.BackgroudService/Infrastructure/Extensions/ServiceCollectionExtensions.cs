using Microsoft.Extensions.DependencyInjection;

namespace Block.BackgroudService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBackgroundServices(this IServiceCollection services)
        {
            services.AddHostedService<QueuedHostedService>();
            services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
        }
    }
}
