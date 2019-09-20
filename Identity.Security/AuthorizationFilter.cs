using LS.Identity.Security.Factory;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Shared.Contracts.Account.ProfileRight.ResponseModel;
using Shared.Contracts.Extensions;
using Shared.Contracts.UserProfile.ResponseModel;
using Shared.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LS.Identity.Security
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public bool AllowMultiple { get; }

        //public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        //{
        //    if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any() ||
        //        actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
        //    {
        //        return continuation();
        //    }
        //    if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
        //    {
        //        return continuation();
        //    }
        //    if (actionContext.ActionDescriptor.GetCustomAttributes<SessionAccessAttribute>().Any() ||
        //        actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<SessionAccessAttribute>().Any())
        //    {
        //        return continuation();
        //    }
        //    if (actionContext.RequestContext.Principal.IsInRole("Administrator"))
        //    {
        //        return continuation();
        //    }
        //    if (actionContext.ActionDescriptor.GetCustomAttributes<AllowReadAccessAttribute>().Any() ||
        //        actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowReadAccessAttribute>().Any())
        //    {
        //        return continuation();
        //    }
        //    var identity = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;
        //    var userId = GetUserId(identity);
        //    if (userId <= 0)
        //    {
        //        return Forbidden();
        //    }

        //    var actionDescriptor = actionContext.ActionDescriptor;
        //    var methodType = actionContext.Request.Method.Method;

        //    var profileAccess = this.GetProfileAccessRight(identity, actionDescriptor.ControllerDescriptor.ControllerName);
        //    var userAccess = this.GetUserAccessRight(1, userId, actionDescriptor.ControllerDescriptor.ControllerName);
        //    if (AccessControl(methodType, profileAccess, userAccess))
        //    {
        //        return continuation();
        //    }

        //    return Forbidden();
        //}

        private int GetUserId(ClaimsIdentity identity)
        {
            var id = 0;
            var claim = identity.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var value = claim.Value;
                int.TryParse(value, out id);
            }
            return id;
        }

        private ProfileRightModel GetProfileAccessRight(ClaimsIdentity identity, string controllerName)
        {
            var claim = identity.Claims.FirstOrDefault(c => c.ValueType.Equals(controllerName));
            ProfileRightModel result = null;
            if (claim != null)
            {
                var right = JsonConvert.DeserializeObject<AccessRightClaim>(claim?.Value);
                result = right.ToModel();
            }
            return result;
        }

        private UserProfileModel GetUserAccessRight(int profileId, int userId, string controllerName)
        {
            return null;
        }

        private bool AccessControl(string methodType, ProfileRightModel organizationProfile, UserProfileModel userProfile)
        {
            var result = false;
            if (organizationProfile == null)
            {
                return false;
            }
            if (userProfile != null)
            {
                organizationProfile.Right = userProfile.Right;
            }
            switch (methodType)
            {
                case "GET":
                    result = organizationProfile.Right.CanRead() || (organizationProfile.SubRight.HasValue && organizationProfile.SubRight.Value.CanRead());
                    break;
                case "POST":
                    result = organizationProfile.Right.CanWrite() || (organizationProfile.SubRight.HasValue && organizationProfile.SubRight.Value.CanWrite());
                    break;
                case "PUT":
                case "PATCH":
                    result = organizationProfile.Right.CanEdit() || (organizationProfile.SubRight.HasValue && organizationProfile.SubRight.Value.CanEdit());
                    break;
                case "DELETE":
                    result = organizationProfile.Right.CanDelete() || (organizationProfile.SubRight.HasValue && organizationProfile.SubRight.Value.CanDelete());
                    break;
            }
            return result;
        }

        private Task<HttpResponseMessage> Forbidden()
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Forbidden));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
