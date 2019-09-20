using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Base
{
    public class LookupModel<TKey, TValue> : ILookupModel
    {
        public LookupModel()
        {

        }

        public LookupModel(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}
