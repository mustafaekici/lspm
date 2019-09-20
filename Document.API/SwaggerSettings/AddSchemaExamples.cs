using FluentValidation;
using Shared.Core.Web.Swagger;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LS.Document.API.SwaggerSettings
{
    public class AddSchemaExamples : ISchemaFilter
    {
        private readonly IValidatorFactory _factory;

        public AddSchemaExamples(IValidatorFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        public void Apply(Schema model, SchemaFilterContext context)
        {
            var validator = _factory.GetValidator(context.SystemType);
            ValidatorDescription.AddRequires(model, context, validator);
        }
    }
}
