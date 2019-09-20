using LS.Identity.Security.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Shared.Contracts.Account.ProfileRight.ResponseModel;
using Shared.Contracts.Extensions;
using Shared.Contracts.UserProfile.ResponseModel;
using Shared.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LS.Identity.Security
{
    public class ProfileAuthorizationHandler : AuthorizationHandler<ProfileRequirement>
    {
        private readonly IHttpContextAccessor _httpContext;
        public ProfileAuthorizationHandler(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProfileRequirement requirement)
        {
            if (context.Resource is AuthorizationFilterContext actionContext)
            {
                var identity = context.User;
                var userId = GetUserId(identity);
                if (userId <= 0)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }
                if (context.User.IsInRole("Administrator"))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
                var actionDescriptor = actionContext.ActionDescriptor;
                var controllerName = actionDescriptor.RouteValues["controller"];
                var methodType = _httpContext.HttpContext.Request.Method;

                var profileAccess = this.GetProfileAccessRight(identity, controllerName);
                var userAccess = this.GetUserAccessRight(1, userId, controllerName);
                if (AccessControl(methodType, profileAccess, userAccess))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            return Task.CompletedTask;
        }

        private int GetUserId(ClaimsPrincipal identity)
        {
            var id = 0;
            var claim = identity.FindFirst(c => c.Type == "id");
            if (claim != null)
            {
                var value = claim.Value;
                int.TryParse(value, out id);
            }
            return id;
        }

        private ProfileRightModel GetProfileAccessRight(ClaimsPrincipal identity, string controllerName)
        {
            ProfileRightModel result = null;
            var claims = identity.FindAll("Profile").Select(c => c.Value);
            foreach (var claim in claims)
            {
                var c = JsonConvert.DeserializeObject<AccessRightClaim>(claim);
                if (c.Name.Equals(controllerName))
                {
                    result = c.ToModel();
                    break;
                }
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
    }
}
