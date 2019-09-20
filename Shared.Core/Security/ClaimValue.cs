using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Security
{
    public abstract class ClaimValue
    {
        public abstract string ValueType();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
