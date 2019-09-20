namespace LS.Document.Business.Core.Exceptions
{
    public class DocumentTypeNotFoundException : BusinessException
    {
        public DocumentTypeNotFoundException()
            : base("Unable to find document type with given ID")
        {
            
        }
    }
}