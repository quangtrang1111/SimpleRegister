using Mapster;
using MediatR;
using SimpleRegister.Application.Commands;
using SimpleRegister.Application.Interfaces;
using SimpleRegister.Application.Models;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRegister.Application.CommandHandlers
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public RegisterAccountCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var userModel = request.Adapt<UserModel>();
            var token = await _identityService.CreateAccountAsync(userModel, request.Password);
            var url = $"{request.HostUrl}?email={request.Email}&token={WebUtility.UrlEncode(token)}";

            const string subject = "Please confirm your registration new account";
            var body = $"<a href=\"{url}\">CLICK ME</a>";

            await _emailService.SendEmailAsync(request.Email, subject, body);

            return Unit.Value;
        }
    }
}
