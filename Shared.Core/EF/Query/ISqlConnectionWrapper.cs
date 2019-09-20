using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shared.Core.EF.Query
{
    public interface ISqlConnectionWrapper<TConnectionConfiguration> : IDisposable
           where TConnectionConfiguration : IConnectionConfiguration
    {
        SqlConnection Connection { get; }
        SqlConnection TryConnect();

        IPagedList<T> ExecutePagedQuery<T>(ISqlQuery<T> sqlQuery, IPagedList<T> pagedList, object conditionParameters = null, string orderBy = null)
        where T : class, new();

        void Disconnect();
    }
}
