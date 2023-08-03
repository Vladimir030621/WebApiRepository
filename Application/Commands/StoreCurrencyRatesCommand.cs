using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class StoreCurrencyRatesCommand : IRequest
    {
        public IEnumerable<Currencyrate> CurrencyRates;

        public StoreCurrencyRatesCommand(IEnumerable<Currencyrate> currencyrates)
        {
            CurrencyRates = currencyrates;
        }
    }
}
