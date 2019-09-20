using Shared.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class ComparisonUsageAttribute : Attribute
    {
        private readonly EnValueType _valueTypes;

        public ComparisonUsageAttribute(EnValueType valueTypes)
        {
            _valueTypes = valueTypes;
        }

        public bool UsedForValueType(EnValueType valueType)
        {
            return (_valueTypes & valueType) == valueType;
        }
    }
}
