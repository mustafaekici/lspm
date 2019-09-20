using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Security
{
    public class AccessRightClaim : ClaimValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Right { get; set; }
        public byte SubRight { get; set; }

        public AccessRightClaim()
        {

        }

        public AccessRightClaim(int id, string name, byte right, byte subRight)
        {
            Id = id;
            Name = name;
            Right = right;
            SubRight = subRight;
        }

        public override string ValueType()
        {
            return Name;
        }
    }
}
