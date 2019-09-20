using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public interface ICreate
    {
        int CreatedUserId { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
