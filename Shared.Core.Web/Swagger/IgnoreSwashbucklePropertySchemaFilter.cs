using Shared.Core.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Core.Web.Swagger
{
    public class IgnoreSwashbucklePropertySchemaFilter : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            var ignoredProperties = (SwashbuckleIgnoreDataMemberAttribute)context.SystemType.GetCustomAttributes(typeof(SwashbuckleIgnoreDataMemberAttribute), true).FirstOrDefault();
            if (ignoredProperties != null)
            {
                foreach (var propertyName in ignoredProperties.IgnoreDataMembers)
                {
                    model.Properties.Remove(FirstCharLower(propertyName));
                }
            }
        }

        private static string FirstCharLower(string s)
        {
            var result = s;
            if (result.Length > 0)
            {
                result = Char.ToLowerInvariant(result[0]) + result.Substring(1);
            }
            return result;
        }
    }
}
