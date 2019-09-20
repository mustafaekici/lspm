using System;

namespace Shared.Contracts.Exceptions
{
    public class UniqueException : BusinessException
    {
        public UniqueException()
        {
        }

        public UniqueException(string message) : base(message)
        {
        }

        public UniqueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
