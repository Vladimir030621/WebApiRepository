using Application.BackgroundServices.Services.Interfaces;
using Application.Queries;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetCurrencyRatesHandler : IRequestHandler<GetCurrencyRatesQuery, IEnumerable<Currencyrate>>
    {
        private readonly ICurrencyRateService _currencyRateService;

        public GetCurrencyRatesHandler(ICurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        public async Task<IEnumerable<Currencyrate>> Handle(GetCurrencyRatesQuery request, CancellationToken cancellationToken)
        {
            return (await _currencyRateService.GetCurrencyRates(request.Type, request.Date)).Result;
        }
    }
}
