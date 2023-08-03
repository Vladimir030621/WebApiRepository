using Application.Queries;
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
    public class GetStoredCurrencyRatesHandler : IRequestHandler<GetStoredCurrencyRatesQuery, IEnumerable<Currencyrate>>
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;

        public GetStoredCurrencyRatesHandler(ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRateRepository = currencyRateRepository;
        }

        public async Task<IEnumerable<Currencyrate>> Handle(GetStoredCurrencyRatesQuery request, CancellationToken cancellationToken)
        {
            return await _currencyRateRepository.GetAll();
        }
    }
}
