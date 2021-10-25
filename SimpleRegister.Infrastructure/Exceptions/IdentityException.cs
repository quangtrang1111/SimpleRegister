using System;

namespace SimpleRegister.Infrastructure.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityException(string message) : base(message)
        {
        }
    }
}
