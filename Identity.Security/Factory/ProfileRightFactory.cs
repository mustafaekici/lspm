using Shared.Contracts.Account.ModuleObject.ResponseModel;
using Shared.Contracts.Account.ProfileRight;
using Shared.Contracts.Account.ProfileRight.ResponseModel;
using Shared.Contracts.Enums;
using Shared.Core.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace LS.Identity.Security.Factory
{
    public static class ProfileRightFactory
    {
        public static ProfileRightModel ToModel(this AccessRightClaim e)
        {
            return new ProfileRightModel
            {
                Id = e.Id,
                Right = (AccessRight)e.Right,
                SubRight = (AccessRight?)e.SubRight,
                ModuleObject = new ModuleObjectModel { Id = 0, Name = e.Name }
            };
        }
    }
}
