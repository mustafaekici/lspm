using System;

namespace Shared.Contracts.Exceptions
{
    public class LookupItemNotFoundException : BusinessException
    {
        public LookupItemNotFoundException()
        {
        }

        public LookupItemNotFoundException(string message) : base(message)
        {
        }

        public LookupItemNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
