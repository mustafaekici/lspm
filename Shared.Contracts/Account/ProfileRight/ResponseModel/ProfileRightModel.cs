using Newtonsoft.Json;
using Shared.Contracts.Account.ModuleObject.ResponseModel;
using Shared.Contracts.Account.Profile.ResponseModel;
using Shared.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Account.ProfileRight.ResponseModel
{
    public class ProfileRightModel
    {
        [JsonProperty(Order = -2)]
        public int Id { get; set; }
        public int ModuleObjectId { get; set; }
        public int ProfileId { get; set; }
        public AccessRight Right { get; set; }
        public AccessRight? SubRight { get; set; }

        public ModuleObjectModel ModuleObject { get; set; }
        public ProfileModel Profile { get; set; }
    }
}
