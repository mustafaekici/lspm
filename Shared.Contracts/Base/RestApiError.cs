using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Contracts.Base
{
    /// <summary>
    /// Validation and exception on api
    /// </summary>
    public class RestApiError
    {

        public RestApiError()
        {

        }

        /// <summary>
        /// Model validation errors
        /// </summary>
        /// <param name="model">Model field for validation errors</param>
        /// <param name="modelState">Model State</param>
        public RestApiError(string model, ModelStateDictionary modelState)
        {
            Field = model;
            var errors = modelState.Values.SelectMany(b => b.Errors).ToList();
            var details = from t in errors
                          select t.ErrorMessage + t.Exception?.Message;
            Message = string.Join(",", details);
        }

        public RestApiError(string message)
        {
            Message = message;
        }

        public RestApiError(string field, string message)
        {
            Field = field;
            Message = message;
        }

        /// <summary>
        ///  Model Field for model state validations
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        ///  Error message
        /// </summary>
        public string Message { get; set; }
    }
}
