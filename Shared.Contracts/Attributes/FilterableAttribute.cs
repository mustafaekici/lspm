using Shared.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterableAttribute : Attribute
    {
        public FilterableAttribute()
        {
        }

        public FilterableAttribute(bool isLookup, EnLookupKeys lookUpKey)
        {
            IsLookup = isLookup;
            LookUpKey = lookUpKey;
        }

        public FilterableAttribute(string validationExpression)
        {
            ValidationExpression = validationExpression;
        }

        public string ValidationExpression { get; private set; }

        public bool IsLookup { get; private set; }

        public EnLookupKeys? LookUpKey { get; private set; }

    }
}
