using Newtonsoft.Json;
using Shared.Contracts.Account.ProfileRight.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Account.Profile.ResponseModel
{
    public class ProfileModel : BaseProfileModel
    {
        [JsonProperty(Order = -2)]
        public int Id { get; set; }

        public List<ProfileRightsModel> Rights { get; set; }
    }
}
