using Newtonsoft.Json;
using Shared.Contracts.ModuleObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Account.ModuleObject.ResponseModel
{
    public class ModuleObjectModel : BaseModuleObjectModel
    {
        [JsonProperty(Order = -2)]
        public int Id { get; set; }
        public List<ModuleSubObjectModel> ModuleSubObjects { get; set; }
    }
}
