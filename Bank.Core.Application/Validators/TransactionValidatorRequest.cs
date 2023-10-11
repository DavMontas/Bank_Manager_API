using Bank.Core.Application.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Validators;

public class CreateTransactionValidatorRequest : AbstractValidator<CreateTransactionRequest>
{
    public CreateTransactionValidatorRequest()
    {
        RuleFor(x => x.AccountFrom)
            .NotEmpty()
            .WithMessage(" AccountFrom is required ");

        RuleFor(x => x.AccountTo)
            .NotEmpty()
            .WithMessage(" AccountTo is required ");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage(" Amount is required ");
    }
}

public class UpdateTransactionValidatorRequest : AbstractValidator<UpdateTransactionRequest>
{
    public UpdateTransactionValidatorRequest()
    {

    }
}
