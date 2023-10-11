using Bank.Core.Application.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Validators;

public class CreateBankAccountValidatorRequest : AbstractValidator<CreateBankAccountRequest>
{
    public CreateBankAccountValidatorRequest()
    {
        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage(" Amount is required ");
    }
}

public class UpdateBankAccountValidatorRequest : AbstractValidator<UpdateBankAccountRequest>
{
    public UpdateBankAccountValidatorRequest()
    {
        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage(" Amount is required ");
    }
}
