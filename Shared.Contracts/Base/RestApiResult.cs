using FluentValidation;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Contracts.Base
{
    /// <summary>
    /// Common response for Api consumer
    /// </summary>
    /// <typeparam name="T">Response type</typeparam>
    public class RestApiResult<T>
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(RestApiResult<T>));
        private readonly IHttpContextAccessor _httpContext;
        public RestApiResult()
        {
            Errors = new List<RestApiError>();
            Status = (byte)RestApiStatus.None;
            SubStatus = (byte)RestApiSubStatus.None;
        }

        /// <summary>
        ///  Api exception
        /// </summary>
        /// <param name="exception">Exception</param>
        public void HandleException(Exception exception)
        {
            if (exception.GetType().IsGenericType && exception.GetType().GetGenericTypeDefinition() == typeof(EntityNotFoundException<>))
            {
                Status = (byte)RestApiStatus.NotFoundException;
                Errors.Add(new RestApiError(exception.Message));
            }
            else if (exception is BusinessException)
            {
                Status = (byte)RestApiStatus.BusinessException;
                Errors.Add(new RestApiError(exception.Message));
            }
            else
            {
                var ex = new RestApiUnhandledException(exception);
                _log.Error(ex);
                Status = (byte)RestApiStatus.UnhandledException;
                Errors.Add(new RestApiError($"An error occurred while processing your request. UniqueId : {ex.UniqueId}"));
            }
        }

        /// <summary>
        ///  Api Business Exception
        /// </summary>
        /// <param name="exception">Exception</param>
        public void HandleBusinessException(Exception exception)
        {
            Status = (byte)RestApiStatus.BusinessException;
            Errors.Add(new RestApiError(exception.Message));
        }

        /// <summary>
        ///  Api model validation
        /// </summary>
        /// <param name="modelState">Model State</param>
        /// <returns></returns>
        public bool HandleValidation(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                Status = (byte)RestApiStatus.ValidationError;
                for (var i = 0; i < modelState.Count; i++)
                {
                    var model = modelState.Keys.ElementAt(i);
                    var state = modelState.Values.ElementAt(i);
                    if (state.Errors.Any())
                        Errors.Add(new RestApiError(model, state.Errors.Select(b => b.ErrorMessage).FirstOrDefault()));
                }
            }
            return modelState.IsValid;
        }

        public bool HandleValidation<T>(T model)
        {
            //var validator = Core.DI.IoC.Instance.Resolve<IValidator<T>>();
            var validator = _httpContext.HttpContext.RequestServices.GetService(typeof(IValidator<T>)) as IValidator<T>;
            var validationResult = validator.Validate(model);
            if (!validationResult.IsValid)
            {
                Status = (byte)RestApiStatus.ValidationError;
                foreach (var err in validationResult.Errors)
                {
                    Errors.Add(new RestApiError(err.PropertyName, err.ErrorMessage));
                }
                return false;
            }
            else
                return true;
        }

        public void HandleValidation(ValidationException ex)
        {
            Status = (byte)RestApiStatus.ValidationError;
            foreach (var validationFailure in ex.Errors)
            {
                Errors.Add(new RestApiError(validationFailure.PropertyName, validationFailure.ErrorMessage));
            }
        }

        /// <summary>
        ///  Api success
        /// </summary>
        /// <param name="data">Response data</param>
        public void HandleSuccess(T data)
        {
            Status = (byte)RestApiStatus.Ok;
            Data = data;
        }

        /// <summary>
        /// Response data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Validation or exception are status type
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// Validation or exception sub status type
        /// </summary>
        public byte SubStatus { get; set; }

        /// <summary>
        /// Validation or exception are list
        /// </summary>
        public List<RestApiError> Errors { get; set; }
    }
}
