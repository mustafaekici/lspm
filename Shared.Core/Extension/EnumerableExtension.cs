using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Extension
{
    public static class EnumerableExtension
    {
        public static void Each<T>(this IEnumerable<T> list, Action<T> action)
        {
            if (list == null) return;
            foreach (var item in list)
                action(item);
        }

        public static Task EachAsync<T>(this IEnumerable<T> list, Action<T> action)
        {
            return Task.Run(() =>
            {
                foreach (var item in list)
                    action(item);
            });
        }

        public static ConcurrentDictionary<TKey, TValue> ToConcurrentDictionary<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> keySelector)
        {
            return new ConcurrentDictionary<TKey, TValue>(source.ToDictionary(keySelector));
        }

        public static string GetValue(this NameValueCollection collection, string key, string defaultValue = "")
        {
            return collection.AllKeys.Contains(key) ? collection[key] : defaultValue;
        }

        public static IEnumerable<T> DistinctBy<T>(this IEnumerable<T> list, Func<T, object> propertySelector)
        {
            return list.GroupBy(propertySelector).Select(x => x.First());
        }

        public static string AsString(this IEnumerable enumerable, string separator)
        {
            if (null == enumerable)
            {
                return string.Empty;
            }
            var enumerator = enumerable.GetEnumerator();
            try
            {
                return enumerator.AsString(separator);
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
        }
        public static string AsString(this IEnumerator enumerator, string separator)
        {
            if (null == enumerator || !enumerator.MoveNext())
            {
                return string.Empty;
            }
            var result = new StringBuilder();
            result.Append(enumerator.Current);
            while (enumerator.MoveNext())
            {
                result.Append(separator);
                result.Append(enumerator.Current);
            }
            return result.ToString();
        }

        public static string AsString(this IEnumerable enumerable, string format, string separator)
        {
            if (null == enumerable)
            {
                return string.Empty;
            }
            var enumerator = enumerable.GetEnumerator();
            try
            {
                return enumerator.AsString(format, separator);
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
        }
        public static string AsString(this IEnumerator enumerator, string format, string separator)
        {
            if (null == enumerator || !enumerator.MoveNext())
            {
                return string.Empty;
            }
            var result = new StringBuilder();
            result.AppendFormat(format, enumerator.Current);
            while (enumerator.MoveNext())
            {
                result.Append(separator);
                result.AppendFormat(format, enumerator.Current);
            }
            return result.ToString();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return null == source || !source.Any();
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var element in collection)
            {
                action(element);
            }
            return collection;
        }

        public static void AddOrUpdate(this IDictionary source, string key, object value)
        {
            if (!source.Contains(key))
                source.Add(key, value);
            else
                source[key] = value;
        }

        public static bool AddWhen<T>(this List<T> source, T value, Func<bool> condition)
        {
            if (condition.Invoke())
            {
                source.Add(value);
                return true;
            }
            return false;
        }

        public static bool AddWhen<T>(this List<T> source, T value, bool condition)
        {
            if (condition)
            {
                source.Add(value);
                return true;
            }
            return false;
        }

        public static IEnumerable<T> WhereEmptyIfNull<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return predicate == null ? source : source.Where(predicate);
        }
    }
}
