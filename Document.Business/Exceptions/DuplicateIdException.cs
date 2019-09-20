namespace LS.Document.Business.Core.Exceptions
{
    public class DuplicateIdException: BusinessException
    {
        public DuplicateIdException()
            : base("There is an already record with given ID")
        {
            
        }
    }
}