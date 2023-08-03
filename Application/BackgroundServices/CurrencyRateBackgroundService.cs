using Application.BackgroundServices.Interfaces;
using Application.BackgroundServices.Services.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.BackgroundServices
{
    public class CurrencyRateBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public CurrencyRateBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
       
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                IScopedProcessingService scopedProcessingService = scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.RunBackgroundWorkAsync(stoppingToken);
            }
        }
    }
}
