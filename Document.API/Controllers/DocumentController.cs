using LS.Document.API.Helpers;
using log4net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Contracts.Document.Model;
using Shared.Contracts.Document.Request.Document;
using Shared.Contracts.Document.Response.Document;
using Shared.Core.Web.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace LS.Document.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [ApiRouteVersion()]
    public class DocumentController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMediator _mediator;

        public DocumentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet, Route("Get")]
        [ProducesResponseType(typeof(GetClientDocumentsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDocumentsByClient([FromQuery]GetClientDocumentsRequest request)
        {
            var clientsDocumentResponse = new GetClientDocumentsResponse();
            var queryHandlerResponse = await _mediator.Send(request);
            clientsDocumentResponse.HandleSuccess(queryHandlerResponse);
            return Ok(clientsDocumentResponse);
        }

        [HttpGet, Route("Download/{documentId:guid}")]
        public async Task<IActionResult> DownloadDocument(Guid documentId)
        {
            var commandHandlerResponse = await _mediator.Send(new DownloadDocumentRequest { DocumentId = documentId });
            //return new DownloadActionResult(commandHandlerResponse.Name, commandHandlerResponse.Content);
            return File(commandHandlerResponse.Content, "application/octet-stream", commandHandlerResponse.Name);
        }

        [HttpPost, Route("Save")]
        [ProducesResponseType(typeof(SaveDocumentResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveDocumentsForClient([FromBody] SaveDocumentRequest request)
        {
            var saveDocumentResponse = new SaveDocumentResponse();
            if (request.File == null || request.File.Length <= 0)
            {
                return new BadRequestObjectResult(new { Message = "Requested file can not be empty." });
            }
            if (!FileTypes.IsValidContentType(request.File.FileName))
            {
                ModelState.AddModelError(request.File.FileName,
                    "File Type Not Supported. Only Word, Pdf, Jpg and Png file types uploadable.");
            }
            if (request.File.Length > 1048576)
            {
                ModelState.AddModelError(request.File.FileName, "Maximum File size of 1 Mb exceeded.");
            }
            if (ModelState.Values.Sum(c => c.Errors.Count) > 0)
            {
                saveDocumentResponse.HandleValidation(ModelState);
                return Ok(saveDocumentResponse);
            }
            var fileModels = new List<FileModel>
                    {
                        new FileModel {Content = request.File.OpenReadStream(), Name = request.File.FileName}
                    };


            if (ModelState.Values.Sum(c => c.Errors.Count) > 0)
            {
                saveDocumentResponse.HandleValidation(ModelState);
                return Ok(saveDocumentResponse);
            }

            var commandHandlerResponse = await _mediator.Send(new SaveDocumentModel
            {
                ProjectId = request.ProjectId,
                DocumentTypeId = request.DocumentTypeId,
                TagId = request.TagId,
                UploadedFiles = fileModels
            });
            saveDocumentResponse.HandleSuccess(commandHandlerResponse);

            return Ok(saveDocumentResponse);
        }

        [HttpPut, Route("Update")]
        [ProducesResponseType(typeof(UpdateDocumentResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDocument([FromBody]UpdateDocumentRequest request)
        {
            var updateDocumentResponse = new UpdateDocumentResponse();

            if (request.File == null || request.File.Length <= 0)
            {
                return new BadRequestObjectResult(new { Message = "Requested file can not be empty." });
            }
            var filePath = Path.GetTempFileName();
            var fileName = Path.GetFileName(filePath);
            if (!FileTypes.IsValidContentType(fileName))
            {
                ModelState.AddModelError(fileName, "File Type Not Supported. Only Word, Pdf, Jpg and Png file types uploadable.");
            }
            if (request.File.Length > 1048576)
            {
                ModelState.AddModelError(fileName, "Maximum File size of 1 Mb exceeded.");
            }
            if (ModelState.Values.Sum(c => c.Errors.Count) > 0)
            {
                updateDocumentResponse.HandleValidation(ModelState);
                return Ok(updateDocumentResponse);
            }
            var updateModel = new UpdateDocumentModel
            {
                DocumentId = request.DocumentId,
                ProjectId = request.ProjectId,
                DocumentTypeId = request.DocumentTypeId,
                TagId = request.TagId,
                UploadedFile = new FileModel
                {
                    Content = request.File.OpenReadStream(),
                    Name = fileName
                }
            };

            var commandHandlerResponse = await _mediator.Send(updateModel);
            updateDocumentResponse.HandleSuccess(commandHandlerResponse);
            return Ok(updateDocumentResponse);
        }

        [HttpDelete, Route("SoftDelete/{documentId:guid}")]
        [ProducesResponseType(typeof(SoftDeleteDocumentResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SoftDeleteDocument(Guid documentId)
        {
            var deleteDocumentResponse = new SoftDeleteDocumentResponse();
            var commandHandlerResponse = await _mediator.Send(new SoftDeleteDocumentModel(documentId));
            deleteDocumentResponse.HandleSuccess(commandHandlerResponse);
            return Ok(deleteDocumentResponse);
        }

        [HttpDelete, Route("HardDelete/{documentId:guid}")]
        [ProducesResponseType(typeof(HardDeleteDocumentResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> HardDeleteDocument(Guid documentId)
        {
            var deleteDocumentResponse = new HardDeleteDocumentResponse();
            var commandHandlerResponse = await _mediator.Send(new HardDeleteDocumentModel(documentId));
            deleteDocumentResponse.HandleSuccess(commandHandlerResponse);
            return Ok(deleteDocumentResponse);
        }
    }
}
