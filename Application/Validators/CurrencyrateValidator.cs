using FluentValidation;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CurrencyrateValidator : AbstractValidator<Currencyrate>
    {
        public CurrencyrateValidator()
        {
            RuleFor(field => field.Code).NotNull().WithMessage("Code cannot be null")
                                        .NotEmpty().WithMessage("Code cannot be empty")
                                        .Length(3).WithMessage("Code length must be 3");

            RuleFor(field => field.Date).NotNull().WithMessage("Date cannot be null")
                                        .NotEmpty().WithMessage("Date cannot be empty");

            RuleFor(field => field.Purchaserate).NotNull().WithMessage("Purchaserate cannot be null")
                                        .GreaterThan(0).WithMessage("Purchaserate must be greater than zero");

            RuleFor(field => field.Sellingrate).NotNull().WithMessage("Sellingrate cannot be null")
                                        .GreaterThan(0).WithMessage("Sellingrate must be greater than zero");

            RuleFor(field => field.Toboid).NotNull().WithMessage("Toboid cannot be null")
                                        .NotEmpty().WithMessage("Toboid cannot be empty");

            RuleFor(field => field.Tobosname).NotNull().WithMessage("Tobosname cannot be null")
                                        .NotEmpty().WithMessage("Tobosname cannot be empty");
        }
    }
}
