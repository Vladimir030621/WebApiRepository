using Application.Commands;
using FluentValidation;


namespace Application.Validators
{
    public class StoreCurrencyRatesCommandValidator : AbstractValidator<StoreCurrencyRatesCommand>
    {
        public StoreCurrencyRatesCommandValidator()
        {
            RuleForEach(field => field.CurrencyRates).SetValidator(new CurrencyrateValidator());
        }
    }
}
