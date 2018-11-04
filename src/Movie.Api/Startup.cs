using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Movie.Api.Validators;
using Block.Http;
using Block.Api.Extensions;
using Movie.Data.Settings;
using Movie.Data.Infrastructure.Extensions;
using Movie.Api.Settings;
using Microsoft.AspNetCore.Http;

namespace Movie.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.Configure<MovieApiSettings>(Configuration.GetSection("MovieApiSettings"));
            services.AddScoped<IHttpClient, StandardHttpClient>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddMvc(options =>
            {
               // options.Filters.Add(typeof(ModelValidationFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MovieSearchQueryValidator>());

            AddElasticSearch(services);

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("AllowAllOrigins");
            app.UseCustomExceptionHandler();

            app.UseDefaultFiles();
            app.UseStaticFiles();

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
