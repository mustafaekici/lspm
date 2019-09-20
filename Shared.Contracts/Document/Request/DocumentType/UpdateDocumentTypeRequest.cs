using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.DocumentType
{
    public class UpdateDocumentTypeRequest: IRequest<DocumentTypeDisplayModel>
    {
        public int DocumentTypeId { get; set; }

        public long ProjectId { get; set; }

        public int OrderNo { get; set; }

        public string TypeName { get; set; }
    }
}