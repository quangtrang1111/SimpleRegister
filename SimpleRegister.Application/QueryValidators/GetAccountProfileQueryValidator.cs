using FluentValidation;
using SimpleRegister.Application.Queries;

namespace SimpleRegister.Application.QueryValidators
{
    public class GetAccountProfileQueryValidator : AbstractValidator<GetAccountProfileQuery>
    {
        public GetAccountProfileQueryValidator()
        {
            RuleFor(v => v.Username).NotEmpty();
        }
    }
}
