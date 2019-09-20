using System;

using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.Document
{
    public class DownloadDocumentRequest: IRequest<FileModel>
    {
        public Guid DocumentId { get; set; }   
    }
}