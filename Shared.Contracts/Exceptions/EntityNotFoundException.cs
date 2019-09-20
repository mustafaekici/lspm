namespace Shared.Contracts.Exceptions
{
    public class EntityNotFoundException<TObject>: BusinessException
    {
        private readonly string _identityKey;

        public EntityNotFoundException(string identityKey)
        {
            _identityKey = identityKey;
        }

        public override string Message => $"Unable to find record. Object: {typeof(TObject).Name}, Requested Id: {_identityKey}";
    }
}