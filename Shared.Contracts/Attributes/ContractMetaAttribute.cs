using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Field)]
    public class ContractMetaAttribute : Attribute
    {
        public ContractMetaAttribute(string displayName, bool isDisplayed = true)
        {
            DisplayName = displayName;
            IsDisplayed = isDisplayed;
        }

        public string DisplayName { get; private set; }

        public bool IsDisplayed { get; private set; }
    }
}
