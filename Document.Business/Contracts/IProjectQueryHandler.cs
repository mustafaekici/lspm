using MediatR;
using Shared.Contracts.Document.Model;
using Shared.Contracts.Document.Request.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Business.Contracts
{
    public interface IProjectQueryHandler :
         IRequestHandler<GetProjectsRequest, List<ProjectDisplayModel>>,
         IRequestHandler<GetProjectRequest, ProjectDisplayModel>
    {

    }
}
