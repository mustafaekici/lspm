using System.Collections.Generic;
using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.Project
{
    public class GetProjectsRequest: IRequest<List<ProjectDisplayModel>>
    {
        
    }
}