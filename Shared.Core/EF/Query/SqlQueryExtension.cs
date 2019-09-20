using Dapper;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.EF.Query
{
    public static class SqlQueryExtension
    {
        internal static bool ValidateSort(this string sort)
        {
            if (string.IsNullOrWhiteSpace(sort)) return true;
            var sorted = sort.Trim();

            if (sorted.All(char.IsLetterOrDigit))
                return true;

            var sortColumns = sorted.Split(',').Select(w => w.Trim());

            foreach (string column in sortColumns)
            {
                var cleanText = column;
                if (column.StartsWith("[", StringComparison.OrdinalIgnoreCase))
                {   //Clean up [ and ]
                    cleanText = column.Substring(1, column.Length - 2);
                }

                if (!cleanText.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
                    return false;
            }
            return true;
        }

        public static async Task<IPagedList<T>> QueryAsPagedAsync<T>(this SqlConnection sqlConnection, ISqlQuery<T> sqlQuery, IPagedList<T> pagedList, object conditionParameters = null, string orderBy = null, bool isDistinct = false)
            where T : class, new()
        {
            Check.NotNull(sqlConnection, nameof(sqlConnection));
            Check.NotNull(sqlQuery, nameof(sqlQuery));
            Check.NotNull(pagedList, nameof(pagedList));



            if (!orderBy.ValidateSort())
            {   //Validate for SQL injection
                throw new ArgumentException("orderBy argument is invalid", nameof(orderBy));
            }

            pagedList.Items = null;
            var query = new StringBuilder(string.Empty);
            query.AppendLine($"WITH T0 AS (SELECT {(isDistinct ? "DISTINCT" : "")} COUNT(0) OVER() AS OverAllRowCount,");
            query.AppendLine(sqlQuery.QueryExpression);
            var whereExpression = sqlQuery.WhereExpression;
            if (!string.IsNullOrWhiteSpace(whereExpression))
            {
                query.AppendLine("WHERE");
                query.AppendLine(whereExpression);
            }
            query.AppendLine("ORDER BY " + (string.IsNullOrWhiteSpace(orderBy) ? "ID DESC" : orderBy));
            var skip = (pagedList.PageIndex - 1) * pagedList.PageSize;
            query.AppendLine($"OFFSET {skip} ROWS FETCH NEXT {pagedList.PageSize} ROWS ONLY");
            query.AppendLine(")");
            query.AppendLine("SELECT * FROM T0");

            var sqlCommand = query.ToString();
            int overAllRowCount = 0;
            var result = new List<T>();
            using (var reader = await sqlConnection.ExecuteReaderAsync(sqlCommand, conditionParameters))
            {
                var rowParser = reader.GetRowParser<T>(typeof(T));
                while (reader.Read())
                {
                    if (reader.Depth == 0)
                    {
                        overAllRowCount = reader.GetInt32(Check.Not(reader.GetOrdinal("OverAllRowCount"), "OverAllRowCountIndex", w => w < 0));
                    }
                    result.Add(rowParser(reader));
                }

                pagedList.Items = result;
                pagedList.TotalCount = overAllRowCount;
                pagedList.PageCount = (int)Math.Ceiling(overAllRowCount / (double)pagedList.PageSize);
            }
            return pagedList;
        }
    }
}
