using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shared.Core.EF.Query
{
    public static class ConnectionFactory
    {
        public static SqlConnection CreateConnection(this IConnectionConfiguration connectionConfiguration)
        {
            return new SqlConnection(connectionConfiguration.ConnectionString);
        }
    }
}
