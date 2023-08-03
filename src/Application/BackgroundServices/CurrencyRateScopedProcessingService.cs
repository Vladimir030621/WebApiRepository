using Application.BackgroundServices.Interfaces;
using Application.BackgroundServices.Services.Interfaces;
using Application.Commands;
using Application.Helpers;
using Application.Queries;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Application.BackgroundServices
{
    public sealed class CurrencyRateScopedProcessingService : IScopedProcessingService
    {
        private readonly IOptions<BackgroundServiceSettings> _options;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        private const string OFFICE = "OFFICE";
        private const int oneHourMs = 3600000;

        public CurrencyRateScopedProcessingService(IOptions<BackgroundServiceSettings> options, 
                                                    ILogger<CurrencyRateScopedProcessingService> logger,
                                                    IMediator mediator)
        {
            _options = options;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task RunBackgroundWorkAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Currency rate background service start");
                try
                {
                    string today = DateHelper.FormatDate(DateTime.Now);

                    var storedCurrencyRates = await _mediator.Send(new GetStoredCurrencyRatesQuery());
                    var storedCurrencyRatesKeys = storedCurrencyRates.Select(c => c.Key).Distinct();

                    var currencyRates = await _mediator.Send(new GetCurrencyRatesQuery(_options?.Value?.Type ?? OFFICE, today));

                    var currencyRatesToAdd = currencyRates.Where(c => !storedCurrencyRatesKeys.Contains(c.Key));

                    await _mediator.Send(new StoreCurrencyRatesCommand(currencyRatesToAdd));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                await Task.Delay(_options?.Value?.TimeSpanMs ?? oneHourMs, stoppingToken);
            }
        }
    }
}
