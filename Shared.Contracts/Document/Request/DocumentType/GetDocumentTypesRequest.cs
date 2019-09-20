using System.Collections.Generic;
using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.DocumentType
{
    public class GetDocumentTypesRequest: IRequest<List<DocumentTypeDisplayModel>>
    {
        
    }
}