using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Shared.Core.Security
{
    public class ComplexClaim<T> : Claim where T : ClaimValue
    {
        public ComplexClaim(string claimType, T claimValue)
            : this(claimType, claimValue, string.Empty)
        {
        }

        public ComplexClaim(string claimType, T claimValue, string issuer)
            : this(claimType, claimValue, issuer, string.Empty)
        {
        }

        public ComplexClaim(string claimType, T claimValue, string issuer, string originalIssuer)
            : base(claimType, claimValue.ToString(), claimValue.ValueType(), issuer, originalIssuer)
        {
        }

        public new T Value => JsonConvert.DeserializeObject<T>(base.Value);
    }
}
