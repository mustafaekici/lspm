using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.DocumentType
{
    public class GetDocumentTypeRequest: IRequest<DocumentTypeDisplayModel>
    {
        public long DocumentTypeId { get; set; }
    }
}