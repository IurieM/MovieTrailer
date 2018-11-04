using Microsoft.Extensions.DependencyInjection;
using Movie.Data.Entities;
using Movie.Data.Settings;
using Nest;
using System;

namespace Movie.Data.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddElasticsearch(this IServiceCollection services, ElasticSearchSettings settings)
        {
            var connectionSettings = new ConnectionSettings(new Uri(settings.Url))
                .DefaultIndex(settings.Index)
                .DefaultMappingFor<MovieTrailer>(m => m
                .PropertyName(p => p.Id, "id"));

            var client = new ElasticClient(connectionSettings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
