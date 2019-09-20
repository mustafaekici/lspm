using System;

namespace Shared.Contracts.Exceptions
{
    public class ClientNotFoundException : BusinessException
    {
        public ClientNotFoundException()
        {
        }

        public ClientNotFoundException(string message) : base(message)
        {
        }

        public ClientNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
