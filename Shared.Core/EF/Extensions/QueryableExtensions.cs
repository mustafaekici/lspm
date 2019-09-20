using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Shared.Core.EF.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> expression, Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? expression.Where(filter) : expression;
        }

        public static IQueryable<T> Order<T>(this IQueryable<T> expression, Func<IQueryable<T>, IQueryable<T>> orderBy = null)
        {
            return orderBy != null ? orderBy(expression) : expression;
        }
    }
}
