using MediatR;
using SimpleRegister.Application.Interfaces;
using SimpleRegister.Application.Models;
using SimpleRegister.Application.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRegister.Application.QueryHandlers
{
    public class GetAccountProfileQueryHandler : IRequestHandler<GetAccountProfileQuery, UserModel>
    {
        private readonly IIdentityService _identityService;

        public GetAccountProfileQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public Task<UserModel> Handle(GetAccountProfileQuery request, CancellationToken cancellationToken)
        {
            var user = _identityService.GetAccountProfile(request.Username);

            return Task.FromResult(user);
        }
    }
}
