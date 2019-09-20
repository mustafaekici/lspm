using MediatR;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Request.Project
{
    public class GetProjectRequest: IRequest<ProjectDisplayModel>
    {
        public long ProjectId { get; set; }
    }
}