using MediatR;

namespace Shared.Contracts.Document.Request.DocumentType
{
    public class DeleteDocumentTypeRequest: IRequest<bool>
    {
        public DeleteDocumentTypeRequest(int documentTypeId)
        {
            DocumentTypeId = documentTypeId;
        }

        public int DocumentTypeId { get; set; }
    }
}