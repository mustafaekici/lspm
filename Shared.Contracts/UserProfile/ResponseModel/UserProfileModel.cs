using Newtonsoft.Json;
using Shared.Contracts.Account.ModuleObject.ResponseModel;
using Shared.Contracts.Account.Profile.ResponseModel;
using Shared.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.UserProfile.ResponseModel
{
    public class UserProfileModel
    {
        [JsonProperty(Order = -2)]
        public int Id { get; set; }
        public int ModuleObjectId { get; set; }
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public AccessRight Right { get; set; }

        public ModuleObjectModel ModuleObject { get; set; }
        public ProfileModel Profile { get; set; }
    }
}
