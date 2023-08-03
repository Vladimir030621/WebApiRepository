using Application.Queries;
using FluentValidation;


namespace Application.Validators
{
    public class GetCurrencyRatesQueryValidator : AbstractValidator<GetCurrencyRatesQuery>
    {
        public GetCurrencyRatesQueryValidator()
        {
            RuleFor(field => field.Type).NotNull().WithMessage("Type cannot be null")
                                        .NotEmpty().WithMessage("Type cannot be empty");

            RuleFor(field => field.Date).NotNull().WithMessage("Date cannot be null")
                                        .NotEmpty().WithMessage("Date cannot be empty");
        }
    }
}
