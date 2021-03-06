using after.Commands.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace after.Validators
{
    public class PatchOrderCommandValidator : AbstractValidator<PatchOrderCommand>
    {
        public PatchOrderCommandValidator()
        {
            RuleFor(x => x.Order.CustomerId)
                .NotEmpty()
                .NotEqual(0);

            RuleFor(x => x.Order.Cost)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
