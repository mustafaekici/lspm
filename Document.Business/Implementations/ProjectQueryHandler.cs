using Document.Business.Contracts;
using Document.Business.DataMappers;
using Infrastructure.Document;
using Microsoft.EntityFrameworkCore;
using Shared.Contracts.Document.Model;
using Shared.Contracts.Document.Request.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Document.Business.Implementations
{
    public class ProjectQueryHandler : IProjectQueryHandler
    {
        private readonly DocumentDataContext _documentDataContext;

        public ProjectQueryHandler(DocumentDataContext documentDataContext)
        {
            _documentDataContext = documentDataContext;
        }

        public async Task<List<ProjectDisplayModel>> Handle(GetProjectsRequest message, CancellationToken cancellationToken)
        {
            return (await _documentDataContext.Projects.AsNoTracking().Where(p => !p.IsDeleted).ToListAsync(cancellationToken: cancellationToken))
                .Select(s => s.ToModel()).ToList();
        }

        public async Task<ProjectDisplayModel> Handle(GetProjectRequest message, CancellationToken cancellationToken)
        {
            return (await _documentDataContext.Projects.FirstOrDefaultAsync(p => !p.IsDeleted && p.Id == message.ProjectId, cancellationToken: cancellationToken)).ToModel();
        }
    }
}
