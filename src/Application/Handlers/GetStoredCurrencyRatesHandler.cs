using Application.Queries;
using CommonServices.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetStoredCurrencyRatesHandler : IRequestHandler<GetStoredCurrencyRatesQuery, ResultModel<IEnumerable<Currencyrate>>>
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public GetStoredCurrencyRatesHandler(ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRateRepository = currencyRateRepository;
        }

        public async Task<ResultModel<IEnumerable<Currencyrate>>> Handle(GetStoredCurrencyRatesQuery request, CancellationToken cancellationToken)
        {
            var currencyRates = await _currencyRateRepository.GetAll();
            return new ResultModel<IEnumerable<Currencyrate>>().Success(currencyRates);
        }
    }
}
