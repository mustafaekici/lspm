using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.DocumentType
{
    public class AddDocumentTypeRequest: IRequest<DocumentTypeDisplayModel>
    {
        public int Id { get; set; }
        public long ProjectId { get; set; }
        public int OrderNo { get; set; }
        public string DocumentType { get; set; }
    }
}