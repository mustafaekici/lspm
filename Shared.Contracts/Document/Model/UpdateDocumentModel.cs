using System;
using MediatR;

namespace Shared.Contracts.Document.Model
{
    public class UpdateDocumentModel: IRequest<bool>
    {
        public Guid DocumentId { get; set; }

        public long ProjectId { get; set; }

        public int DocumentTypeId { get; set; }

        public string TagId { get; set; }

        public FileModel UploadedFile { get; set; }
    }
}