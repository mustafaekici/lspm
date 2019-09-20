using Newtonsoft.Json;
using Shared.Contracts.Enums;
using Shared.Contracts.ModuleObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Account.ProfileRight.ResponseModel
{
    public class ProfileRightsModel
    {
        [JsonProperty(Order = -2)]
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public AccessRight Right { get; set; }
        public AccessRight? SubRight { get; set; }

        public List<ModuleSubObjectModel> ModuleSubObjects { get; set; }
    }
}
