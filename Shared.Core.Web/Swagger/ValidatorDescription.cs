using FluentValidation;
using FluentValidation.Validators;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Web.Swagger
{
    public class ValidatorDescription
    {

        public static void AddRequires(Schema model, SchemaFilterContext context, IValidator validator)
        {
            // use IoC or FluentValidatorFactory to get AbstractValidator<T> instance
            if (validator == null) return;
            if (model.Required == null)
                model.Required = new List<string>();

            var validatorDescriptor = validator.CreateDescriptor();
            foreach (var key in model.Properties.Keys)
            {
                foreach (var propertyValidator in validatorDescriptor
                    .GetValidatorsForMember(ToPascalCase(key)))
                {
                    if (propertyValidator is NotNullValidator
                        || propertyValidator is NotEmptyValidator)
                        model.Required.Add(key);

                    if (propertyValidator is LengthValidator lengthValidator)
                    {
                        if (lengthValidator.Max > 0)
                            model.Properties[key].MaxLength = lengthValidator.Max;

                        model.Properties[key].MinLength = lengthValidator.Min;
                    }

                    if (propertyValidator is RegularExpressionValidator expressionValidator)
                        model.Properties[key].Pattern = expressionValidator.Expression;

                    // Add more validation properties here;
                }
            }
        }

        /// <summary>
        ///     To convert case as swagger may be using lower camel case
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static string ToPascalCase(string inputString)
        {
            // If there are 0 or 1 characters, just return the string.
            if (inputString == null) return null;
            if (inputString.Length < 2) return inputString.ToUpper();
            return inputString.Substring(0, 1).ToUpper() + inputString.Substring(1);
        }
    }
}
