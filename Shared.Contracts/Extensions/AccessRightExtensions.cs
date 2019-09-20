using Shared.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Extensions
{
    public static class AccessRightExtensions
    {
        public static bool CanRead(this AccessRight right)
        {
            return Equals(right, AccessRight.Read);
        }

        public static bool CanWrite(this AccessRight right)
        {
            return Equals(right, AccessRight.Write);
        }

        public static bool CanEdit(this AccessRight right)
        {
            return Equals(right, AccessRight.Edit);
        }

        public static bool CanDelete(this AccessRight right)
        {
            return Equals(right, AccessRight.Delete);
        }

        private static bool Equals(AccessRight source, AccessRight target)
        {
            return (source & target) == target;
        }
    }
}
