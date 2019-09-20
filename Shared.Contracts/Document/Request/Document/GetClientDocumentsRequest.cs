using System.Collections.Generic;

using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.Document
{
    public class GetClientDocumentsRequest: IRequest<List<DocumentDisplayModel>>
    {
        public long ProjectId { get; set; }

        public string TagId { get; set; }
    }
}