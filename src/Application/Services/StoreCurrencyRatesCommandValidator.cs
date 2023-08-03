using Application.Commands;
using Application.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StoreCurrencyRatesCommandValidator : AbstractValidator<StoreCurrencyRatesCommand>
    {
        public StoreCurrencyRatesCommandValidator()
        {
            RuleForEach(field => field.CurrencyRates).SetValidator(new CurrencyrateValidator());
        }
    }
}
