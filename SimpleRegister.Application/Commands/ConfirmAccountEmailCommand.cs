using MediatR;

namespace SimpleRegister.Application.Commands
{
    public class ConfirmAccountEmailCommand : IRequest
    {
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
