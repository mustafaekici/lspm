using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
