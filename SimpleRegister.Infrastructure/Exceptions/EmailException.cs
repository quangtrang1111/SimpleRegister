using System;

namespace SimpleRegister.Infrastructure.Exceptions
{
    public class EmailException : Exception
    {
        public EmailException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
