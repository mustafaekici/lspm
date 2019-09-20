using log4net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Document.Request.DocumentType;
using Shared.Contracts.Document.Response.DocumentType;
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
    [Authorize]
    [ApiRouteVersion()]
    public class DocumentTypeController : Controller
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMediator _documentTypeMediator;

        public DocumentTypeController(IMediator mediator)
        {
            _documentTypeMediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet, Route("GetAll")]
        [ProducesResponseType(typeof(GetDocumentTypesResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            var getDocumentTypesResponse = new GetDocumentTypesResponse();
            var queryHandlerResponse = await _documentTypeMediator.Send(new GetDocumentTypesRequest());
            getDocumentTypesResponse.HandleSuccess(queryHandlerResponse);
            return Ok(getDocumentTypesResponse);
        }

        [HttpGet, Route("AsLookup/{projectId:int}")]
        [ProducesResponseType(typeof(GetDocumentTypeLookupResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AsLookup(int projectId)
        {
            var getDocumentTypeLookupResponseLookup = new GetDocumentTypeLookupResponse();
            var response = await _documentTypeMediator.Send(new GetDocumentTypeLookupRequest { ProjectId = projectId });
            getDocumentTypeLookupResponseLookup.HandleSuccess(response);
            return Ok(getDocumentTypeLookupResponseLookup);
        }

        [HttpGet, Route("Get/{documentTypeId:long}")]
        [ProducesResponseType(typeof(GetDocumentTypeResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDocumentType(long documentTypeId)
        {
            var getDocumentTypeResponse = new GetDocumentTypeResponse();
            var queryHandlerResponse = await _documentTypeMediator.Send(new GetDocumentTypeRequest { DocumentTypeId = documentTypeId });
            getDocumentTypeResponse.HandleSuccess(queryHandlerResponse);
            return Ok(getDocumentTypeResponse);
        }

        [HttpPost, Route("Add")]
        [ProducesResponseType(typeof(AddDocumentTypeResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddDocumentType([FromBody] AddDocumentTypeRequest request)
        {
            var addDocumentTypeResponse = new AddDocumentTypeResponse();
            var commandHandlerResponse = await _documentTypeMediator.Send(request);
            addDocumentTypeResponse.HandleSuccess(commandHandlerResponse);
            return Ok(addDocumentTypeResponse);
        }

        [HttpPut, Route("Update")]
        [ProducesResponseType(typeof(UpdateDocumentTypeResponsee), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDocumentType([FromBody]UpdateDocumentTypeRequest request)
        {
            var updateDocumentResponse = new UpdateDocumentTypeResponsee();
            var commandHandlerResponse = await _documentTypeMediator.Send(request);
            updateDocumentResponse.HandleSuccess(commandHandlerResponse);
            return Ok(updateDocumentResponse);
        }

        [HttpDelete, Route("Delete/{documentTypeId:int}")]
        [ProducesResponseType(typeof(DeleteDocumentTypeResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDocumentType(int documentTypeId)
        {
            var deleteDocumentTypeResponse = new DeleteDocumentTypeResponse();
            var commandHandlerResponse = await _documentTypeMediator.Send(new DeleteDocumentTypeRequest(documentTypeId));
            deleteDocumentTypeResponse.HandleSuccess(commandHandlerResponse);
            return Ok(deleteDocumentTypeResponse);
        }
    }
}
