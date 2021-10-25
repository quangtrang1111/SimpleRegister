using MediatR;
using SimpleRegister.Application.Models;

namespace SimpleRegister.Application.Queries
{
    public class GetAccountProfileQuery : IRequest<UserModel>
    {
        public string Username { get; set; }
    }
}
