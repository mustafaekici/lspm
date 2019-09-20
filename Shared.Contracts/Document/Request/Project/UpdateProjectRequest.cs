using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.Project
{
    public class UpdateProjectRequest: IRequest<ProjectDisplayModel>
    {
        public long ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}