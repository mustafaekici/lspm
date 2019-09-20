namespace LS.Document.Business.Core.Exceptions
{
    public class DocumentNotFoundException : BusinessException
    {
        public DocumentNotFoundException() 
            : base("Unable to find document with given ID.")
        {
        }
    }
}