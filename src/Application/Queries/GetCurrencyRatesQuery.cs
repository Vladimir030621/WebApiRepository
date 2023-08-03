using Infrastructure.Data;
using MediatR;


namespace Application.Queries
{
    public class GetCurrencyRatesQuery : IRequest<IEnumerable<Currencyrate>>
    {
        public string Type { get; set; }
        public string Date { get; set; }

        public GetCurrencyRatesQuery(string type, string date)
        {
            Type = type;
            Date = date;
        }
    }
}
