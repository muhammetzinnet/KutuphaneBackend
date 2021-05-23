using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ReturnBookValidator : AbstractValidator<ReturnBook>
    {
        public ReturnBookValidator()
        {
            RuleFor(r => r.ReturnBookId).NotNull();
            RuleFor(r => r.BookName).NotNull();
            RuleFor(r => r.FirstName).MinimumLength(3);
            RuleFor(r => r.ReturnDate).NotNull();

        }
    }
}
