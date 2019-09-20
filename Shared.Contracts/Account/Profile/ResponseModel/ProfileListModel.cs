using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Account.Profile.ResponseModel
{
    public class ProfileListModel : BaseProfileModel
    {
        [JsonProperty(Order = -2)]
        public int Id { get; set; }
    }
}
