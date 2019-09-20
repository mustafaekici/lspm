using System;

namespace Shared.Contracts.Exceptions
{
    public class ClientGroupNotFoundException : BusinessException
    {
        public ClientGroupNotFoundException()
        {
        }

        public ClientGroupNotFoundException(string message) : base(message)
        {
        }

        public ClientGroupNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
