using System;

namespace Shared.Contracts.Exceptions
{
    public class UniqueItemException : BusinessException
    {
        public UniqueItemException()
        {
        }

        public UniqueItemException(string message) : base(message)
        {
        }

        public UniqueItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
