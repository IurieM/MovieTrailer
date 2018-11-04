using Block.Api.Extensions;
using Block.BackgroudService.Infrastructure.Extensions;
using Block.Http;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movie.Data.Commands;
using Movie.Data.Infrastructure.Extensions;
using Movie.Data.Settings;
using System.Reflection;
using Youtube.Api.Settings;

namespace Youtube.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<YoutubeSettings>(Configuration.GetSection("YoutubeSettings"));
            services.AddScoped<IHttpClient, StandardHttpClient>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SaveOrUpdateMovieTrailerCommand).GetTypeInfo().Assembly);

            services.AddBackgroundServices();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            AddElasticSearch(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCustomExceptionHandler();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void AddElasticSearch(IServiceCollection services)
        {
            var settings = new ElasticSearchSettings();
            Configuration.GetSection("ElasticSearchSettings").Bind(settings);
            services.AddElasticsearch(settings);
        }
    }
}
