using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF.Query
{
    public interface ISqlQuery<T> where T : class
    {
        string QueryExpression { get; }

        string WhereExpression { get; }
    }
}
