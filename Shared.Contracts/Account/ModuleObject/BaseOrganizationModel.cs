using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.ModuleObject
{
    public class BaseModuleObjectModel
    {
        public string Name { get; set; }
    }

    public class ModuleSubObjectModel : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
