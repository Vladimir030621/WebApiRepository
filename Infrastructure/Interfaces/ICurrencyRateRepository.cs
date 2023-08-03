using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICurrencyRateRepository
    {
        Task<IEnumerable<Currencyrate>> GetAll();

        void StoreCurrencyRates(IEnumerable<Currencyrate> currencyrates);
    }
}
