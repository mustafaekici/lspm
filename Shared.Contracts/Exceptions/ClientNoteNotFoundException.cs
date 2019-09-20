using System;

namespace Shared.Contracts.Exceptions
{
    public class ClientNoteNotFoundException : BusinessException
    {
        public ClientNoteNotFoundException()
        {
        }

        public ClientNoteNotFoundException(string message) : base(message)
        {
        }

        public ClientNoteNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
