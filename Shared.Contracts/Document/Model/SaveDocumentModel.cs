using System.Collections.Generic;
using System.IO;
using MediatR;

namespace Shared.Contracts.Document.Model
{
    public class SaveDocumentModel : IRequest<bool>
    {
        public long ProjectId { get; set; }

        public int DocumentTypeId { get; set; }

        public string TagId { get; set; }

        public List<FileModel> UploadedFiles { get; set; }
    }

    public class FileModel
    {
        public string Name { get; set; }

        public Stream Content { get; set; }
    }
}