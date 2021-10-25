using MediatR;

namespace SimpleRegister.Application.Commands
{
    public class RegisterAccountCommand : IRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string HostUrl { get; set; }
    }
}
