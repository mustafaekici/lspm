using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Shared.Core.Security
{
    public class PrincipalContext : IPrincipalContext
    {
        private readonly ClaimsPrincipal _principal;

        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public int ProfileId { get; set; }
        public int LanguageId { get; set; }
        public string Timezone { get; set; }
        public double TimezoneOffset { get; set; }
        public string DatePattern { get; set; }
        public string TimePattern { get; set; }
        public string DecimalSymbol { get; set; }

        public PrincipalContext(IPrincipal principal)
        {
            _principal = principal as ClaimsPrincipal;
            UserId = this.GetUserId();
            OrganizationId = this.GetOrganizationId();
            ProfileId = this.GetProfileId();
            LanguageId = this.GetLanguageId();
            Timezone = this.GetTimeZone();
            TimezoneOffset = this.GetOffset();
            DatePattern = this.GetDatePattern();
            TimePattern = this.GetTimePattern();
            DecimalSymbol = this.GetDecimalSymbol();
        }

        public bool UserIsInRole(string role)
        {
            var result = _principal.IsInRole(role);
            return result;
        }
        public int GetUserId(ClaimsIdentity identity)
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

        public int GetUserId()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var id = 0;
            var claim = identity.FindFirst(c => c.Type == "id");
            if (claim != null)
            {
                var value = claim.Value;
                int.TryParse(value, out id);
            }
            return id;
        }

        public int GetOrganizationId()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var id = 0;
            var claim = identity.FindFirst(c => c.Type == "OrganizationId");
            if (claim != null)
            {
                var value = claim.Value;
                int.TryParse(value, out id);
            }
            return id;
        }

        public int GetProfileId()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var id = 0;
            var claim = identity.FindFirst(c => c.Type == "ProfileId");
            if (claim != null)
            {
                var value = claim.Value;
                int.TryParse(value, out id);
            }
            return id;
        }

        public int GetLanguageId()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var id = 0;
            var claim = identity.FindFirst(c => c.Type == "LanguageId");
            if (claim != null)
            {
                var value = claim.Value;
                int.TryParse(value, out id);
            }
            return id;
        }

        public string GetTimeZone()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var timeZone = string.Empty;
            var claim = identity.FindFirst(c => c.Type == "TimeZone");
            if (claim != null)
            {
                timeZone = claim.Value;
            }
            return timeZone;
        }

        public double GetOffset()
        {
            double ts = 0;
            var timezoneId = this.GetTimeZone();
            if (!string.IsNullOrEmpty(timezoneId))
            {
                var timezone = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
                if (timezone != null)
                {
                    ts = timezone.BaseUtcOffset.TotalMinutes;
                }
            }
            return ts;
        }

        public string GetDatePattern()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var datePattern = string.Empty;
            var claim = identity.FindFirst(c => c.Type == "DatePattern");
            if (claim != null)
            {
                datePattern = claim.Value;
            }
            return datePattern;
        }

        public string GetTimePattern()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var timePattern = string.Empty;
            var claim = identity.FindFirst(c => c.Type == "TimePattern");
            if (claim != null)
            {
                timePattern = claim.Value;
            }
            return timePattern;
        }

        public string GetDecimalSymbol()
        {
            var identity = _principal.Identity as ClaimsIdentity;
            var decimalSymbol = string.Empty;
            var claim = identity.FindFirst(c => c.Type == "DecimalSymbol");
            if (claim != null)
            {
                decimalSymbol = claim.Value;
            }
            return decimalSymbol;
        }

        public AccessRightClaim GetProfileAccessRight(string moduleName)
        {
            var claims = _principal.FindAll("Profile").Select(c => c.Value);
            AccessRightClaim right = null;
            foreach (var claim in claims)
            {
                var c = JsonConvert.DeserializeObject<AccessRightClaim>(claim);
                if (c.Name.Equals(moduleName))
                {
                    right = c;
                    break;
                }
            }
            return right;
        }
    }
}
