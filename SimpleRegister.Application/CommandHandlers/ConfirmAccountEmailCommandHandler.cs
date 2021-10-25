using MediatR;
using SimpleRegister.Application.Commands;
using SimpleRegister.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRegister.Application.CommandHandlers
{
    public class ConfirmAccountEmailCommandHandler : IRequestHandler<ConfirmAccountEmailCommand>
    {
        private readonly IIdentityService _identityService;

        public ConfirmAccountEmailCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Unit> Handle(ConfirmAccountEmailCommand request, CancellationToken cancellationToken)
        {
            // For testing, after confim email success, would automatic login user
            // In real work we should separate this to 2 action then the frontend would control the flow
            await _identityService.ConfirmEmailThenSignInAsync(request.Email, request.Token);

            return Unit.Value;
        }
    }
}
