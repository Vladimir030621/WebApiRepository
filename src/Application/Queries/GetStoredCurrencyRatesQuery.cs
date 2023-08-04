using CommonServices.Models;
using Infrastructure.Data;
using MediatR;


namespace Application.Queries
{
    public class GetStoredCurrencyRatesQuery : IRequest<ResultModel<IEnumerable<Currencyrate>>>
    {
    }
}
