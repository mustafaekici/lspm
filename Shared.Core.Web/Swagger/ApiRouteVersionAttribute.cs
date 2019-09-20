using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Web.Swagger
{
    public sealed class ApiRouteVersionAttribute : RouteAttribute
    {
        const string basePrefix = "api/v{api-version:apiVersion=1.0}/";
        public ApiRouteVersionAttribute(string routePrefix = "[controller]") : base($"{basePrefix}{routePrefix}") { }
    }
}
