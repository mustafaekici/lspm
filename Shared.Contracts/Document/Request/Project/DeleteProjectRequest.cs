using MediatR;

namespace Shared.Contracts.Document.Request.Project
{
    public class DeleteProjectRequest: IRequest<bool>
    {
        public long ProjectId { get; set; }
    }
}