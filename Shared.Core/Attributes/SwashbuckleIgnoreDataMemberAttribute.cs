using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class SwashbuckleIgnoreDataMemberAttribute : Attribute
    {
        public SwashbuckleIgnoreDataMemberAttribute(params string[] ignoreProperties)
        {
            _ignoreProperties = ignoreProperties;
        }

        private string[] _ignoreProperties { get; set; }

        public string[] IgnoreDataMembers { get { return _ignoreProperties; } }

    }
}
