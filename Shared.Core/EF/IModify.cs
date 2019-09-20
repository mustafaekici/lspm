using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public interface IModify
    {
        int? ModifiedUserId { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}
