using System;

namespace Shared.Contracts.Exceptions
{
    public class TaskNotFoundException : BusinessException
    {
        public TaskNotFoundException()
        {
        }

        public TaskNotFoundException(string message) : base(message)
        {
        }

        public TaskNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
