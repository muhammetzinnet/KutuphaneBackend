using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class KindValidator : AbstractValidator<Kind>
    {
        public KindValidator()
        {
            RuleFor(k => k.KindName).NotEmpty();
            RuleFor(k => k.KindName).MinimumLength(3);
            RuleFor(k => k.KindName).NotNull();
        }
    }
}
