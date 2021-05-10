using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LendValidator : AbstractValidator<Lend>
    {
        public LendValidator()
        {
            RuleFor(l => l.LendId).Null();
        }
    }
}
