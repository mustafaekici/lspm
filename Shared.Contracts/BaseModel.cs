using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts
{
    public abstract class BaseModel<T> : IModel<T> where T : IComparable
    {
        [JsonProperty(Order = -2)]
        public T Id { get; set; }
    }
}
