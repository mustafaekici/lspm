using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Web.Swagger
{
    public static class Extensions
    {

        public static void AddSwaggerGenFx(this IServiceCollection services, string apiname, string version = "v1")
        {
            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.SwaggerDoc("v1",
                        new Info
                        {
                            Title = apiname,
                            Version = version
                        }
                    );

                c.OperationFilter<SwaggerDefaultValues>();
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                c.SchemaFilter<IgnoreSwashbucklePropertySchemaFilter>();
            });
        }

        public static void UseSwaggerUIFx(this IApplicationBuilder app, string apiname, string version = "v1")
        {
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle(apiname);
                c.ShowRequestHeaders();
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{apiname.ToUpperInvariant()} {version.ToUpperInvariant()}");
                c.ConfigureOAuth2(apiname + ".Swagger", "secret", "", "Swagger UI");
            });
        }
    }
}
