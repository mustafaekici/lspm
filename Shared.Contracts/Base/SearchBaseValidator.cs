using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Base
{
    public abstract class SearchBaseValidator<T> : AbstractValidator<T> where T : SearchBase
    {
        protected SearchBaseValidator()
        {
            RuleFor(c => c.Skip).NotNull().GreaterThan(-1);
            RuleFor(c => c.Take).NotEmpty().GreaterThan(0);
        }
    }
}
