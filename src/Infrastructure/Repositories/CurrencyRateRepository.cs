using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private ElmaApiDevContext _dbContext;

        public CurrencyRateRepository(ElmaApiDevContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Currencyrate currencyrate)
        {
            _dbContext.Currencyrates.Add(currencyrate);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Currencyrate>> GetAll()
        {
            return await _dbContext.Currencyrates.ToListAsync();
        }

        public void StoreCurrencyRates(IEnumerable<Currencyrate> currencyrates)
        {
            using (var dbContext = new ElmaApiDevContext())
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        _dbContext.AddRange(currencyrates);
                        _dbContext.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
