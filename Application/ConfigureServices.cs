using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Refit;
using Application.BackgroundServices.Services.Interfaces;
using Application.BackgroundServices;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Application.Behaviors;
using FluentValidation;
using Application.BackgroundServices.Interfaces;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddRefitRoutes(configuration);

            services.AddBackgroundServices();

            services.AddDbContext<ElmaApiDevContext>();

            services.AddScoped<ICurrencyRateRepository, CurrencyRateRepository>();

            services.Configure<BackgroundServiceSettings>(configuration.GetSection(nameof(BackgroundServiceSettings)));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }

        public static IServiceCollection AddRefitRoutes(this IServiceCollection services, IConfiguration configuration)
        {
            RefitRoutes routes = new RefitRoutes();
            configuration.GetSection(nameof(RefitRoutes)).Bind(routes);

            if (string.IsNullOrEmpty(routes.ElmaDevRoute))
            {
                throw new ArgumentException(nameof(RefitRoutes));
            }

            services.AddRefitClient<ICurrencyRateService>()
                   .ConfigureHttpClient(c =>
                   {
                       c.BaseAddress = new Uri(routes.ElmaDevRoute);
                   });

            return services;
        }

        public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
        {
            services.AddHostedService<CurrencyRateBackgroundService>();
            services.AddScoped<IScopedProcessingService, CurrencyRateScopedProcessingService>();

            return services;
        }
    }
}
