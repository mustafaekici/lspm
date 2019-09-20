using System.Collections.Generic;
using Shared.Contracts.Base;
using Shared.Contracts.Document.Model;

namespace Shared.Contracts.Document.Response.Project
{
    public class GetProjectsResponse: RestApiResult<List<ProjectDisplayModel>>
    {
    }
}
