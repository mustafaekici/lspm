using LS.Document.Business.Core.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LS.Document.API.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _environment;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;

        public HttpGlobalExceptionFilter(IHostingEnvironment environment, ILogger<HttpGlobalExceptionFilter> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(ValidationException))
            {
                var validationResult = new RestApiResult<object>();
                validationResult.HandleValidation((ValidationException)context.Exception);
                context.Result = new BadRequestObjectResult(validationResult);
            }
            else if (context.Exception.GetType() == typeof(DuplicateIdException))
            {
                var validationResult = new RestApiResult<object>();
                validationResult.HandleBusinessException(context.Exception);
                context.Result = new BadRequestObjectResult(validationResult);
            }
            else if (context.Exception.GetType() == typeof(DocumentNotFoundException))
            {
                var response = new NotFoundObjectResult(new { context.Exception.Message });
                context.Result = response;
            }
            else if (context.Exception.GetType() == typeof(DocumentTypeNotFoundException))
            {
                var response = new NotFoundObjectResult(new { context.Exception.Message });
                context.Result = response;
            }
            else if (context.Exception.GetType() == typeof(ProjectNotFoundException))
            {
                var response = new NotFoundObjectResult(new { context.Exception.Message });
                context.Result = response;
            }
            else
            {
                var unhandledExceptionResult = new RestApiResult<object>();
                unhandledExceptionResult.HandleException(context.Exception);
                context.Result = new ObjectResult(unhandledExceptionResult);
            }
            context.ExceptionHandled = true;
            _logger.LogError($"Exception occured while process document.", context.Exception);
        }
    }
}
