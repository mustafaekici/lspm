
using System;

namespace Shared.Contracts.Exceptions
{
    public class AccountTypeNotFoundException : BusinessException
    {
        public AccountTypeNotFoundException()
        {
        }

        public AccountTypeNotFoundException(string message) : base(message)
        {
        }

        public AccountTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
