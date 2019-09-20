using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Core.EF.Extensions
{
    public class SortValidator
    {
        public static string SortModel<T>(string input)
        {
            var sort = "Id ASC";
            if (!string.IsNullOrEmpty(input))
            {
                var sorts = input.Split(' ');
                if (sorts.Length > 0)
                {
                    var sortDir = "ASC";
                    var sortName = sorts[0].ToLowerInvariant();
                    if (sorts.Length > 1)
                    {
                        sortDir = sorts[1];
                    }
                    var propertyInfo = typeof(T).GetProperties()
                        .FirstOrDefault(c => string.Equals(c.Name.ToLowerInvariant(), sortName, StringComparison.CurrentCultureIgnoreCase));
                    if (propertyInfo != null)
                    {
                        sort = $"{sortName} {sortDir}";
                    }
                }
            }
            return sort;
        }
        public static string SortModelGuid<T>(string input)
        {
            var sort = "CreatedDate " + input;
            if (!string.IsNullOrEmpty(input))
            {
                var sorts = input.Split(' ');
                if (sorts.Length > 0)
                {
                    var sortDir = "ASC";
                    var sortName = sorts[0].ToLowerInvariant();
                    if (sorts.Length > 1)
                    {
                        sortDir = sorts[1];
                    }
                    var propertyInfo = typeof(T).GetProperties()
                        .FirstOrDefault(c => string.Equals(c.Name.ToLowerInvariant(), sortName, StringComparison.CurrentCultureIgnoreCase));
                    if (propertyInfo != null)
                    {
                        sort = $"{sortName} {sortDir}";
                    }
                }
            }
            return sort;
        }
    }
}
