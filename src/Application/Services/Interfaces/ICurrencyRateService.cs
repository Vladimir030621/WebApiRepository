using CommonServices.Models;
using Infrastructure.Data;
using Refit;

namespace Application.BackgroundServices.Services.Interfaces
{
    public interface ICurrencyRateService
    {
        [Get("/api/elma/CurrencyRates")]
        public Task<ResultModel<IEnumerable<Currencyrate>>> GetCurrencyRates(string type, string date);
    }
}
