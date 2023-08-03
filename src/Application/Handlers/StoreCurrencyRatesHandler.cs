using Application.Commands;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class StoreCurrencyRatesHandler : IRequestHandler<StoreCurrencyRatesCommand>
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;
        public StoreCurrencyRatesHandler(ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRateRepository = currencyRateRepository;
        }
        public async Task<Unit> Handle(StoreCurrencyRatesCommand request, CancellationToken cancellationToken)
        {
            _currencyRateRepository.StoreCurrencyRates(request.CurrencyRates);

            return await Task.FromResult(Unit.Value);
        }
    }
}
