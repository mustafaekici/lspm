using System;
using MediatR;

namespace Shared.Contracts.Document.Model
{
    public class SoftDeleteDocumentModel : DeleteDocumentModel
    {
        public SoftDeleteDocumentModel(Guid documentId)
        {
            DocumentId = documentId;
        }
    }

    public class HardDeleteDocumentModel : DeleteDocumentModel
    {
        public HardDeleteDocumentModel(Guid documentId)
        {
            DocumentId = documentId;
        }
    }

    public abstract class DeleteDocumentModel : IRequest<bool>
    {
        public Guid DocumentId { get; set; }
    }
}