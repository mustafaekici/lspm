using log4net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Document.Request.Project;
using Shared.Contracts.Document.Response.Project;
using Shared.Contracts.Extensions;
using Shared.Core.Web.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace LS.Document.API.Controllers
{
    [ApiVersion("1.0")]
    //[Authorize]
    [ApiRouteVersion()]
    public class ProjectController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMediator _projectMediator;

        public ProjectController(IMediator projectMediator)
        {
            if (projectMediator == null) throw new ArgumentNullException(nameof(projectMediator));
            _projectMediator = projectMediator;
        }

        [HttpGet, Route("Get")]
        [ProducesResponseType(typeof(GetProjectsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProjects()
        {
            var getProjectsResponse = new GetProjectsResponse();
            Logger.Info($"Get Projects request is received. Time in UTC: {DateTime.UtcNow}");
            var commandHandlerResponse = await _projectMediator.Send(new GetProjectsRequest());
            getProjectsResponse.HandleSuccess(commandHandlerResponse);
            return Ok(getProjectsResponse);
        }

        [HttpGet, Route("Get/{projectId:long}")]
        [ProducesResponseType(typeof(GetProjectResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProjects(long projectId)
        {
            var getProjectResponse = new GetProjectResponse();
            Logger.Info($"Get Projects request is received. Time in UTC: {DateTime.UtcNow}");
            var commandHandlerResponse = await _projectMediator.Send(new GetProjectRequest { ProjectId = projectId });
            getProjectResponse.HandleSuccess(commandHandlerResponse);
            return Ok(getProjectResponse);
        }

        [HttpPost, Route("Add")]
        [ProducesResponseType(typeof(AddNewProjectResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddNewProject([FromBody] AddProjectRequest request)
        {
            var newProjectResponse = new AddNewProjectResponse();
            Logger.Info($"Add new project request is received. Time in UTC: {DateTime.UtcNow}, request: {request.ToJson()}");
            var commandHandlerResponse = await _projectMediator.Send(request);
            newProjectResponse.HandleSuccess(commandHandlerResponse);
            return Ok(newProjectResponse);
        }

        [HttpPut, Route("Update")]
        [ProducesResponseType(typeof(UpdateProjectResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateExistingProject([FromBody]UpdateProjectRequest request)
        {
            var updateProjectResponse = new UpdateProjectResponse();
            Logger.Info($"Update existing project request is received. Time in UTC: {DateTime.UtcNow}, request: {request.ToJson()}");
            var commandHandlerResponse = await _projectMediator.Send(request);
            updateProjectResponse.HandleSuccess(commandHandlerResponse);
            return Ok(updateProjectResponse);
        }

        [HttpDelete, Route("Delete/{projectId:long}")]
        [ProducesResponseType(typeof(DeleteProjectResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProject(long projectId)
        {
            var deleteProjectResponse = new DeleteProjectResponse();
            var commandHandlerResponse = await _projectMediator.Send(new DeleteProjectRequest { ProjectId = projectId });
            deleteProjectResponse.HandleSuccess(commandHandlerResponse);
            return Ok(deleteProjectResponse);
        }
    }
}
