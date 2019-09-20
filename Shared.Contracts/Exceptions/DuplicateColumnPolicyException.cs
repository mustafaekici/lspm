using System;
using System.Runtime.Serialization;

namespace Shared.Contracts.Exceptions
{
    public sealed class DuplicateColumnPolicyException : Exception
    {
        public string ColumnName { get; private set; }
        public DuplicateColumnPolicyException(string columnName)
        {
            ColumnName = columnName;
        }

        private DuplicateColumnPolicyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info != null)
            {
                ColumnName = info.GetString("ColumnName");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("ColumnName", ColumnName);
        }
    }
}
