using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Shared.Core.Security
{
    public interface IPrincipalContext
    {
        int UserId { get; set; }
        int OrganizationId { get; set; }
        int ProfileId { get; set; }
        int LanguageId { get; set; }
        string Timezone { get; set; }
        double TimezoneOffset { get; set; }
        string DatePattern { get; set; }
        string TimePattern { get; set; }
        string DecimalSymbol { get; set; }


        string GetDatePattern();
        string GetDecimalSymbol();
        int GetLanguageId();
        int GetOrganizationId();
        int GetProfileId();
        string GetTimePattern();
        string GetTimeZone();
        double GetOffset();
        int GetUserId();
        int GetUserId(ClaimsIdentity identity);
        bool UserIsInRole(string role);
        AccessRightClaim GetProfileAccessRight(string moduleName);
    }
}
