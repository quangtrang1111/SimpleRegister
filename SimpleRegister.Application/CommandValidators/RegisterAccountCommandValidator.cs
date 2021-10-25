using FluentValidation;
using SimpleRegister.Application.Commands;

namespace SimpleRegister.Application.CommandValidators
{
    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        public RegisterAccountCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().EmailAddress();
            RuleFor(v => v.Password).NotEmpty().MinimumLength(6);
            RuleFor(v => v.PhoneNumber).NotEmpty().Matches(@"^(\+?\d{1,20})$");
            RuleFor(v => v.Firstname).NotEmpty();
            RuleFor(v => v.Lastname).NotEmpty();
            RuleFor(v => v.Address).NotEmpty();
        }
    }
}
