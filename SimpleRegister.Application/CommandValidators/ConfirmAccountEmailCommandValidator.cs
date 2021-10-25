using FluentValidation;
using SimpleRegister.Application.Commands;

namespace SimpleRegister.Application.CommandValidators
{

    public class ConfirmAccountEmailCommandValidator : AbstractValidator<ConfirmAccountEmailCommand>
    {
        public ConfirmAccountEmailCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().EmailAddress();
            RuleFor(v => v.Token).NotEmpty();
        }
    }
}
